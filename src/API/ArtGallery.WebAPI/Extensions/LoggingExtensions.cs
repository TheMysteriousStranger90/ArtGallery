using System.Reflection;
using Elastic.Channels;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Serilog.Sinks;
using Serilog;
using Serilog.Debugging;
using Serilog.Exceptions;
using ArtGallery.WebAPI.Logging;

namespace ArtGallery.WebAPI.Extensions;

public static class LoggingExtensions
{
    public static void ConfigureEnhancedLogging(this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        SelfLog.Enable(Console.Error);

        var assemblyName = Assembly.GetExecutingAssembly().GetName().Name ?? "ArtGalleryAPI";
        var environment = builder.Environment.EnvironmentName;

        var loggerConfiguration = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.WithExceptionDetails()
            .Enrich.WithProperty("Application", assemblyName)
            .Enrich.WithProperty("ApplicationName", "ArtGalleryAPI")
            .Enrich.WithProperty("Environment", environment);

        ConfigureElasticsearchSink(loggerConfiguration, assemblyName, configuration);

        var logger = loggerConfiguration.CreateLogger();
        Log.Logger = logger;

        builder.Host.UseSerilog(logger, dispose: true);

        builder.Services.AddSingleton<IBusinessEventLogger, BusinessEventLogger>();

        Log.Information("Enhanced logging configured for {Application} in {Environment} environment",
            assemblyName, environment);
    }

    private static void ConfigureElasticsearchSink(
        LoggerConfiguration loggerConfig,
        string assemblyName,
        IConfiguration configuration)
    {
        var elasticsearchUri = configuration["ELASTICSEARCH_URI"] ?? configuration["ElasticsearchSettings:Uri"];

        if (string.IsNullOrEmpty(elasticsearchUri))
        {
            Log.Information("Elasticsearch URI not configured, skipping Elasticsearch sink");
            return;
        }

        try
        {
            var elasticSettings = configuration.GetSection("ElasticsearchSettings");
            var username = elasticSettings["Username"];
            var password = elasticSettings["Password"];
            var enableResiliency = elasticSettings.GetValue<bool>("EnableResiliency");

            loggerConfig.WriteTo.Elasticsearch(
                new[] { new Uri(elasticsearchUri) },
                opts =>
                {
                    opts.DataStream = new DataStreamName(
                        "logs",
                        "dotnet",
                        assemblyName.ToLower().Replace(".", "-"));

                    opts.BootstrapMethod = enableResiliency
                        ? BootstrapMethod.Silent
                        : BootstrapMethod.None;

                    opts.ConfigureChannel = channelOpts =>
                    {
                        channelOpts.BufferOptions = new BufferOptions
                        {
                            InboundBufferMaxSize = 100_000,
                            OutboundBufferMaxSize = 1_000,
                            OutboundBufferMaxLifetime = TimeSpan.FromSeconds(30)
                        };
                    };
                },
                transport =>
                {
                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    {
                        transport.Authentication(new Elastic.Transport.BasicAuthentication(username, password));
                    }

                    transport.ServerCertificateValidationCallback((sender, cert, chain, errors) => true);

                    transport.RequestTimeout(TimeSpan.FromSeconds(30));
                }
            );

            Log.Information("Elasticsearch sink configured successfully for {ElasticsearchUri}", elasticsearchUri);
        }
        catch (Exception ex)
        {
            Log.Warning(ex, "Failed to configure Elasticsearch sink for {ElasticsearchUri}", elasticsearchUri);
        }
    }
}