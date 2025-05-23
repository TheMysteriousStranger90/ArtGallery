using ArtGallery.Application.Contracts;
using ArtGallery.Application.Extensions;
using ArtGallery.Identity.Context;
using ArtGallery.Identity.Extensions;
using ArtGallery.Infrastructure.Extensions;
using ArtGallery.Persistence.Context;
using ArtGallery.Persistence.Extensions;
using ArtGallery.WebAPI.Extensions;
using ArtGallery.WebAPI.Middleware;
using ArtGallery.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Prometheus;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure environment variables first
builder.ConfigureEnvironmentVariables();

// Configure enhanced logging (combines both approaches)
builder.ConfigureEnhancedLogging();

// Configure TLS certificates BEFORE any other Kestrel configuration
builder.ConfigureTlsCertificates();

// Configure error alerts and monitoring
builder.ConfigureErrorAlerts();
builder.ConfigureMonitoring(); 

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
builder.Services.AddHealthChecks()
    .ForwardToPrometheus();

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

app.UseRequestLogging();
app.UseMiddleware<ErrorAlertMiddleware>();
app.UseGlobalExceptionHandling();
app.UseRateLimiter();
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
    var logger = Log.ForContext<Program>();

    try
    {
        logger.Information("Starting database initialization...");

        // Get DbContext instances
        var artGalleryContext = services.GetRequiredService<ArtGalleryDbContext>();
        var identityContext = services.GetRequiredService<ArtGalleryIdentityDbContext>();
        
        /*
        // Ensure databases are created
        await artGalleryContext.Database.EnsureCreatedAsync();
        await identityContext.Database.EnsureCreatedAsync();
        */
        
        // Run migrations
        await artGalleryContext.Database.MigrateAsync();
        await identityContext.Database.MigrateAsync();

        logger.Information("Database initialization completed");

        // Seed data
        logger.Information("Starting application seeding...");
        await ArtGallery.Identity.SeedData.SeedDataUserInitializer.Initialize(services);
        logger.Information("Application seeding completed");
    }
    catch (Exception ex)
    {
        logger.Fatal(ex, "An error occurred during database initialization or application seeding");
        throw;
    }
}

try
{
    Log.Information("Starting ArtGallery WebAPI");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}