using System.Text.Json;
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
app.UseHttpsRedirection();
app.UseCors("Open");
app.UseRateLimiter();
app.UseRouting();

// Custom middleware for logging requests and responses
app.Use(async (context, next) =>
{
    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();

    if (context.Request.Path.StartsWithSegments("/api"))
    {
        logger.LogInformation("Method: {Method}, Path: {Path}", context.Request.Method, context.Request.Path);
        logger.LogInformation("Content-Type: {ContentType}", context.Request.ContentType);
        logger.LogInformation("Content-Length: {ContentLength}", context.Request.ContentLength);
        logger.LogInformation("Authorization Header: {HasAuth}", context.Request.Headers.ContainsKey("Authorization"));

        if (context.Request.Method == "POST" && context.Request.ContentLength > 0)
        {
            context.Request.EnableBuffering();
            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0;
            logger.LogInformation("Request Body: {Body}", body);
        }
    }

    try
    {
        await next();

        if (context.Request.Path.StartsWithSegments("/api"))
        {
            logger.LogInformation("=== RESPONSE ===");
            logger.LogInformation("Status: {StatusCode} for {Method} {Path}",
                context.Response.StatusCode, context.Request.Method, context.Request.Path);
        }
    }
    catch (JsonException ex)
    {
        logger.LogError(ex, "JSON deserialization error for request {Method} {Path}",
            context.Request.Method, context.Request.Path);

        context.Response.StatusCode = 400;
        context.Response.ContentType = "application/json";

        var errorResponse = new
        {
            errors = new[] { "Invalid JSON format in request body" },
            details = ex.Message
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        return;
    }
    catch (InvalidOperationException ex) when (ex.Message.Contains("model binding"))
    {
        logger.LogError(ex, "Model binding error for request {Method} {Path}",
            context.Request.Method, context.Request.Path);

        context.Response.StatusCode = 400;
        context.Response.ContentType = "application/json";

        var errorResponse = new
        {
            errors = new[] { "Invalid request model" },
            details = ex.Message
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        return;
    }
});

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