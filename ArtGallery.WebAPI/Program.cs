using ArtGallery.Application.Contracts;
using ArtGallery.Application.Extensions;
using ArtGallery.Identity.Context;
using ArtGallery.Identity.Extensions;
using ArtGallery.Infrastructure.Extensions;
using ArtGallery.Persistence.Context;
using ArtGallery.Persistence.Extensions;
using ArtGallery.WebAPI.Extensions;
using ArtGallery.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Prometheus;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure environment variables and settings
builder.ConfigureEnvironmentVariables();

// Configure TLS certificates for HTTPS
builder.ConfigureTlsCertificates();

// Configure Serilog logging
try
{
    builder.Services.ConfigureSerilog(builder.Configuration);
    builder.Host.UseSerilog();
}
catch (Exception ex)
{
    Console.WriteLine($"Error configuring Serilog: {ex.Message}");
    
    builder.Host.UseSerilog((context, services, configuration) => configuration
        .WriteTo.Console()
        .WriteTo.File("logs/error-.txt", rollingInterval: RollingInterval.Day));
}

// Configure core services
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.UseHttpClientMetrics();

// Configure DataProtection
builder.ConfigureDataProtection();

// Configure additional services
builder.Services.AddMemoryCache();
builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddSwaggerDocumentation();

// Configure rate limiting
builder.ConfigureRateLimiting();

// Configure OpenTelemetry
builder.ConfigureOpenTelemetry();

// Configure health checks
builder.Services.AddHealthChecks().ForwardToPrometheus();

// Configure CORS
builder.ConfigureCors();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();

    app.Use(async (context, next) =>
    {
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            context.Response.Redirect("/docs");
            return;
        }

        await next();
    });
}

app.UseRateLimiter();
app.UseRequestLogging();
app.UseGlobalExceptionHandling();
app.UseHttpsRedirection();
app.UseCors("Open");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseMetricServer();
app.UseHttpMetrics();
app.MapMetrics();
app.MapHealthChecks("/health");

// Initialize databases and seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    var logger = loggerFactory.CreateLogger<Program>();

    try
    {
        logger.LogInformation("Starting database initialization...");

        // Get DbContext instances
        var artGalleryContext = services.GetRequiredService<ArtGalleryDbContext>();
        var identityContext = services.GetRequiredService<ArtGalleryIdentityDbContext>();
        
        /*
        // Ensure databases are created
        await artGalleryContext.Database.EnsureCreatedAsync();
        await identityContext.Database.EnsureCreatedAsync();
        */
        
        // Then run migrations
        await artGalleryContext.Database.MigrateAsync();
        await identityContext.Database.MigrateAsync();

        logger.LogInformation("Database initialization completed.");

        // Now seed data
        logger.LogInformation("Starting application seeding...");
        await ArtGallery.Identity.SeedData.SeedDataUserInitializer.Initialize(services);
        logger.LogInformation("Application seeding completed.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred during database initialization or application seeding.");
    }
}

app.Run();