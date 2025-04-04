using System.Reflection;
using Elastic.Channels;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Serilog.Sinks;
using Serilog;
using Serilog.Debugging;
using Serilog.Exceptions;

namespace ArtGallery.WebAPI.Extensions;

public static class ConfigureSerilogExtensions
{
    public static void ConfigureSerilog(this IServiceCollection services, IConfiguration configuration)
    {
        SelfLog.Enable(Console.Error);
        var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

        var loggerConfiguration = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithEnvironmentName()
            .Enrich.WithProcessId()
            .Enrich.WithThreadId()
            .Enrich.WithExceptionDetails()
            .Enrich.WithProperty("Application", assemblyName)
            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}");

        var elasticSettings = configuration.GetSection("ElasticsearchSettings");
        if (ShouldEnableElasticsearch(elasticSettings))
        {
            ConfigureElasticsearchSink(loggerConfiguration, assemblyName, elasticSettings);
        }

        Log.Logger = loggerConfiguration.CreateLogger();
    }

    private static bool ShouldEnableElasticsearch(IConfigurationSection elasticSettings)
    {
        return elasticSettings.GetValue<bool>("Enabled") && 
               !string.IsNullOrEmpty(elasticSettings["Uri"]);
    }

    private static void ConfigureElasticsearchSink(
        LoggerConfiguration loggerConfig,
        string assemblyName,
        IConfigurationSection elasticSettings)
    {
        try
        {
            var uri = elasticSettings["Uri"];
            var username = elasticSettings["Username"];
            var password = elasticSettings["Password"];
            
            // Use the new Elastic.Serilog.Sinks configuration
            loggerConfig.WriteTo.Elasticsearch(
                new[] { new Uri(uri) },
                opts =>
                {
                    // Configure datastream for the application
                    opts.DataStream = new DataStreamName(
                        "logs", 
                        "dotnet", 
                        assemblyName.ToLower());
                    
                    // Set bootstrap method based on configuration
                    opts.BootstrapMethod = elasticSettings.GetValue<bool>("EnableResiliency") 
                        ? BootstrapMethod.Silent 
                        : BootstrapMethod.None;
                    
                    // Configure channel for buffer options
                    opts.ConfigureChannel = channelOpts =>
                    {
                        channelOpts.BufferOptions = new BufferOptions
                        {

                        };
                    };
                },
                transport =>
                {
                    // Configure authentication if credentials are provided
                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    {
                        transport.Authentication(new Elastic.Transport.BasicAuthentication(username, password));
                    }
                    
                    // Optional: Configure TLS validation
                    transport.ServerCertificateValidationCallback((o, cert, chain, errors) => true);
                }
            );
            
            SelfLog.WriteLine("Elasticsearch sink configured successfully");
            Console.WriteLine("Elasticsearch sink configured successfully");
        }
        catch (Exception ex)
        {
            SelfLog.WriteLine($"Elasticsearch configuration error: {ex}");
            Log.Warning(ex, "Failed to configure Elasticsearch sink");
        }
    }
}