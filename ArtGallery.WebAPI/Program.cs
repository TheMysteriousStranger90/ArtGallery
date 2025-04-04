using System.Diagnostics;
using ArtGallery.Application.Contracts;
using ArtGallery.Application.Extensions;
using ArtGallery.Identity.Extensions;
using ArtGallery.Infrastructure.Extensions;
using ArtGallery.Persistence.Extensions;
using ArtGallery.WebAPI.Extensions;
using ArtGallery.WebAPI.Services;
using Microsoft.AspNetCore.RateLimiting;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Prometheus;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog with conditional Elasticsearch
builder.Services.ConfigureSerilog(builder.Configuration);
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddMemoryCache();

builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();

// Replace the existing Swagger config with our enhanced version
builder.Services.AddSwaggerDocumentation();

// Configure rate limiting
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    // Registration rate limit: 3 requests per minute
    options.AddFixedWindowLimiter("registration", opt =>
    {
        opt.Window = TimeSpan.FromMinutes(1);
        opt.PermitLimit = 3;
        opt.QueueLimit = 0;
    });

    // Authentication rate limit: 5 requests per minute
    options.AddFixedWindowLimiter("authentication", opt =>
    {
        opt.Window = TimeSpan.FromMinutes(1);
        opt.PermitLimit = 5;
        opt.QueueLimit = 0;
    });
});


try
{
    var serviceName = "ArtGalleryAPI";
    var serviceVersion = "1.0.0";

    // Define ActivitySource for manual instrumentation
    builder.Services.AddSingleton(new ActivitySource(serviceName));

    builder.Services.AddOpenTelemetry()
        .ConfigureResource(resource => resource
            .AddService(serviceName: serviceName, serviceVersion: serviceVersion)
            .AddTelemetrySdk()
            .AddEnvironmentVariableDetector())
        .WithTracing(tracing =>
        {
            tracing
                .AddSource(serviceName)
                .AddAspNetCoreInstrumentation(options => { options.RecordException = true; })
                .AddHttpClientInstrumentation();
            
            try
            {
                var otlpEndpoint = builder.Configuration.GetValue<string>("OpenTelemetry:OtlpEndpoint") ??
                                   "http://localhost:4317";
                tracing.AddOtlpExporter(opts =>
                {
                    opts.Endpoint = new Uri(otlpEndpoint);
                    opts.TimeoutMilliseconds = 5000;
                });
            }
            catch (Exception ex)
            {
                Log.Warning(ex,
                    "Failed to configure OpenTelemetry OTLP exporter for tracing. Using console exporter as fallback.");
            }
        })
        .WithMetrics(metrics =>
        {
            metrics
                .AddMeter(serviceName)
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation();

            // Add OTLP exporter with retry logic and timeout
            try
            {
                var otlpEndpoint = builder.Configuration.GetValue<string>("OpenTelemetry:OtlpEndpoint") ??
                                   "http://localhost:4317";
                metrics.AddOtlpExporter(opts =>
                {
                    opts.Endpoint = new Uri(otlpEndpoint);
                    opts.TimeoutMilliseconds = 5000;
                });
            }
            catch (Exception ex)
            {
                Log.Warning(ex,
                    "Failed to configure OpenTelemetry OTLP exporter for metrics. Using console exporter as fallback.");
            }
        });
}
catch (Exception ex)
{
    Log.Error(ex, "Failed to initialize OpenTelemetry");
}


// Add health checks conditionally
builder.Services.AddHealthChecks().ForwardToPrometheus();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Replace the standard Swagger middleware with our enhanced version
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

// Enable rate limiting middleware
app.UseRateLimiter();

app.UseRequestLogging();
app.UseGlobalExceptionHandling();

app.UseHttpsRedirection();

app.UseCors("Open");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseHttpMetrics(); // Collect HTTP metrics
app.MapMetrics(); // Expose /metrics endpoint

app.MapHealthChecks("/health");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    var logger = loggerFactory.CreateLogger<Program>();

    try
    {
        logger.LogInformation("Starting application seeding...");
        await ArtGallery.Identity.SeedData.SeedDataUserInitializer.Initialize(services);
        logger.LogInformation("Application seeding completed.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred during application seeding.");
    }
}

app.Run();