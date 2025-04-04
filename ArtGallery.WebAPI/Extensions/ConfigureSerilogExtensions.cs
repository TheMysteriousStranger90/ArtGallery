using System.Reflection;
using Serilog;
using Serilog.Debugging;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;

namespace ArtGallery.WebAPI.Extensions;

public static class ConfigureSerilogExtensions
{
    public static void ConfigureSerilog(this IServiceCollection services, IConfiguration configuration)
    {
        // Enable Serilog self-logging for troubleshooting
        SelfLog.Enable(Console.Error);

        // Get application name from assembly
        var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        
        // Start building the logger configuration
        var loggerConfiguration = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithEnvironmentName()
            .Enrich.WithProcessId()
            .Enrich.WithThreadId()
            .Enrich.WithExceptionDetails()
            .Enrich.WithProperty("Application", assemblyName)
            .WriteTo.Console();
        
        // Only use Elasticsearch in Production or if explicitly enabled
        var useElasticsearch = configuration.GetValue<bool>("ElasticsearchSettings:Enabled");
        var isProduction = configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT") == "Production";
        
        if ((isProduction || useElasticsearch) && !string.IsNullOrEmpty(configuration["ElasticsearchSettings:Uri"]))
        {
            try
            {
                // Test connection to Elasticsearch (with a short timeout)
                var connectionAvailable = TestElasticsearchConnection(configuration["ElasticsearchSettings:Uri"]);
                
                if (connectionAvailable)
                {
                    var elasticsearchSettings = configuration.GetSection("ElasticsearchSettings");
                    
                    loggerConfiguration.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration["ElasticsearchSettings:Uri"]))
                    {
                        IndexFormat = $"{assemblyName.ToLower()}-{DateTime.UtcNow:yyyy-MM}",
                        AutoRegisterTemplate = true,
                        NumberOfReplicas = 1,
                        NumberOfShards = 2,
                        ModifyConnectionSettings = conn =>
                        {
                            if (!string.IsNullOrEmpty(elasticsearchSettings["Username"]) && 
                                !string.IsNullOrEmpty(elasticsearchSettings["Password"]))
                            {
                                conn.BasicAuthentication(elasticsearchSettings["Username"], elasticsearchSettings["Password"]);
                            }
                            return conn;
                        },
                        BatchAction = ElasticOpType.Create,
                        EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                                          EmitEventFailureHandling.WriteToFailureSink |
                                          EmitEventFailureHandling.RaiseCallback,
                        FailureCallback = e => SelfLog.WriteLine("Unable to submit event to Elasticsearch: {0}", e.MessageTemplate),
                        BufferBaseFilename = Path.Combine(AppContext.BaseDirectory, "logs", "buffer"),
                        BufferLogShippingInterval = TimeSpan.FromSeconds(5),
                    });
                    
                    SelfLog.WriteLine("Elasticsearch sink configured successfully");
                }
                else
                {
                    SelfLog.WriteLine("Elasticsearch connection test failed - using fallback logging only");
                }
            }
            catch (Exception ex)
            {
                SelfLog.WriteLine("Error configuring Elasticsearch sink: {0}", ex);
            }
        }
        
        Log.Logger = loggerConfiguration.CreateLogger();
    }
    
    private static bool TestElasticsearchConnection(string uri)
    {
        try
        {
            using var client = new HttpClient { Timeout = TimeSpan.FromSeconds(2) };
            var response = client.GetAsync(uri).GetAwaiter().GetResult();
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}