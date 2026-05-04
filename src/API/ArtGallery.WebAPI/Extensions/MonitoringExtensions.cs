using ArtGallery.WebAPI.Middleware;
using ArtGallery.WebAPI.Services;

namespace ArtGallery.WebAPI.Extensions;

public static class MonitoringExtensions
{
    public static void ConfigureMonitoring(this WebApplicationBuilder builder)
    {
        builder.Services.AddErrorNotifier();
        
        builder.Services.AddHostedService<HealthCheckMonitorService>();
    }
}