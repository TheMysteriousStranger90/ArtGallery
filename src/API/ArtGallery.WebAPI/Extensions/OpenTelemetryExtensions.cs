using System.Diagnostics;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Prometheus;
using Serilog;

namespace ArtGallery.WebAPI.Extensions;

public static class OpenTelemetryExtensions
{
    public static void ConfigureOpenTelemetry(this WebApplicationBuilder builder)
    {
        try
        {
            var serviceName = "ArtGalleryAPI";
            var serviceVersion = "1.0.0";
            
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
    }
}