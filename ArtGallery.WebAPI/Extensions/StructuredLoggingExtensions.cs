using ArtGallery.WebAPI.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Filters;

namespace ArtGallery.WebAPI.Extensions;

public static class StructuredLoggingExtensions
{
    public static void ConfigureEnhancedLogging(this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
    
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithMachineName()
            .Enrich.WithProcessId()
            .Enrich.WithThreadId()
            .Enrich.WithProperty("ApplicationName", "ArtGalleryAPI")
            .Enrich.WithProperty("Environment", builder.Environment.EnvironmentName)
            .MinimumLevel.Information()
            .WriteTo.Console(outputTemplate: 
                "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
            .WriteTo.File("logs/app.log", 
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        Log.Logger = logger;
    
        builder.Host.UseSerilog(logger, dispose: true);
    
        builder.Services.AddSingleton<IBusinessEventLogger, BusinessEventLogger>();
    }
}