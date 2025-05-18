using System.Diagnostics;
using ArtGallery.Application.Contracts;
using ArtGallery.Application.Extensions;
using ArtGallery.Identity.Context;
using ArtGallery.Identity.Extensions;
using ArtGallery.Infrastructure.Extensions;
using ArtGallery.Persistence.Context;
using ArtGallery.Persistence.Extensions;
using ArtGallery.WebAPI.Extensions;
using ArtGallery.WebAPI.Services;
using DotNetEnv;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Prometheus;
using Serilog;
using TlsCertificateLoader.Extensions;

string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower();
string envFileName = environmentName == "production" ? ".env.production" : ".env";

List<string> possiblePaths = new List<string>();

if (environmentName == "production")
{
    possiblePaths.Add(Path.Combine(AppContext.BaseDirectory, envFileName));
    possiblePaths.Add(envFileName);
    possiblePaths.Add(Path.Combine("/", envFileName));
    Console.WriteLine($"Running in Production. Will check multiple locations for {envFileName}");
}
else
{
    string solutionLevelPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
    possiblePaths.Add(Path.Combine(solutionLevelPath, envFileName));
    possiblePaths.Add(Path.Combine(AppContext.BaseDirectory, envFileName));
    possiblePaths.Add(envFileName);
    Console.WriteLine($"Running in {environmentName ?? "Unknown (assuming Development)"}. Will check multiple locations for {envFileName}");
}

bool fileLoaded = false;
foreach (string path in possiblePaths)
{
    Console.WriteLine($"Checking for env file at: {path}");
    
    if (File.Exists(path))
    {
        Env.Load(path);
        Console.WriteLine($"✅ Successfully loaded environment variables from {path}");
        fileLoaded = true;
        break;
    }
}

if (!fileLoaded)
{
    Console.WriteLine($"❌ No {envFileName} file found in any of the search locations.");
}

var builder = WebApplication.CreateBuilder(args);

TlsCertificateLoader.TlsCertificateLoader tlsCertificateLoader = null;

if (builder.Environment.IsProduction())
{
    string effectiveCertificatePath;
    var certificateEnvVarPath = Environment.GetEnvironmentVariable("CERTIFICATE_PATH");

    if (!string.IsNullOrEmpty(certificateEnvVarPath))
    {
        effectiveCertificatePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory,"..", "..", "..", "..", certificateEnvVarPath));
    }
    else
    {
        effectiveCertificatePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "certificates"));
    }

    var fullChainPath = Path.Combine(effectiveCertificatePath, "fullchain.pem");
    var privateKeyPath = Path.Combine(effectiveCertificatePath, "privkey.pem");
    
    Console.WriteLine($"Effective certificate path: {effectiveCertificatePath}");
    Console.WriteLine($"Checking for certificate files:");
    Console.WriteLine($"  - fullchain.pem: {(File.Exists(fullChainPath) ? "FOUND" : "NOT FOUND")} at {fullChainPath}");
    Console.WriteLine($"  - privkey.pem: {(File.Exists(privateKeyPath) ? "FOUND" : "NOT FOUND")} at {privateKeyPath}");

    if (File.Exists(fullChainPath) && File.Exists(privateKeyPath))
    {
        Console.WriteLine("Both certificate files found. Configuring HTTPS...");
        tlsCertificateLoader = new TlsCertificateLoader.TlsCertificateLoader(
            fullChainPath,
            privateKeyPath);

        builder.Services.AddSingleton(tlsCertificateLoader);
        builder.Services.AddHostedService<CertificateRefreshService>();

        var certificateWatcher = new FileSystemWatcher(effectiveCertificatePath)
        {
            NotifyFilter = NotifyFilters.LastWrite,
            Filter = "*.pem",
            EnableRaisingEvents = true
        };

        certificateWatcher.Changed += (sender, e) =>
        {
            Console.WriteLine($"Certificate file changed: {e.Name}");
            try
            {
                tlsCertificateLoader.RefreshDefaultCertificates();
                Console.WriteLine("Certificates refreshed successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error refreshing certificates: {ex.Message}");
            }
        };
    }
    else
    {
        Console.WriteLine("HTTPS certificate files not found. Running with HTTP only.");
    }
    
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(8080);
        
        if (tlsCertificateLoader != null)
        {
            options.ListenAnyIP(8081, listenOptions =>
            {
                listenOptions.SetTlsHandshakeCallbackOptions(tlsCertificateLoader);
                listenOptions.SetHttpsConnectionAdapterOptions(tlsCertificateLoader);
                listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
            });
        }
    });
}

// Configure Serilog with conditional Elasticsearch
try
{
    builder.Services.ConfigureSerilog(builder.Configuration);
    builder.Host.UseSerilog();
}
catch (Exception ex)
{
    Console.WriteLine($"Error configuring Serilog: {ex.Message}");

    // Fallback to basic logging
    builder.Host.UseSerilog((context, services, configuration) => configuration
        .WriteTo.Console()
        .WriteTo.File("logs/error-.txt", rollingInterval: RollingInterval.Day));
}

// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.UseHttpClientMetrics(); 

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"/home/app/.aspnet/DataProtection-Keys"))
    .SetApplicationName("ArtGalleryAPI");



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

app.UseMetricServer();
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