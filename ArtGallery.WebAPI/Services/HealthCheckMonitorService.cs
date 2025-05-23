using ArtGallery.WebAPI.Errors;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ArtGallery.WebAPI.Services;

public class HealthCheckMonitorService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<HealthCheckMonitorService> _logger;
    private readonly IErrorNotifier _errorNotifier;
    private readonly IConfiguration _configuration;

    public HealthCheckMonitorService(
        IServiceProvider serviceProvider,
        ILogger<HealthCheckMonitorService> logger,
        IErrorNotifier errorNotifier,
        IConfiguration configuration)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _errorNotifier = errorNotifier;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var monitoringInterval = _configuration.GetValue<int>("Monitoring:HealthCheckIntervalSeconds", 60);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var healthCheckService = scope.ServiceProvider.GetRequiredService<HealthCheckService>();

                var result = await healthCheckService.CheckHealthAsync(stoppingToken);

                if (result.Status != HealthStatus.Healthy)
                {
                    _logger.LogWarning("Health check returned status: {Status}", result.Status);

                    var unhealthyChecks = result.Entries
                        .Where(e => e.Value.Status != HealthStatus.Healthy)
                        .ToDictionary(e => e.Key, e => new
                        {
                            Status = e.Value.Status.ToString(),
                            Description = e.Value.Description,
                            Duration = e.Value.Duration
                        });

                    if (unhealthyChecks.Any())
                    {
                        await _errorNotifier.NotifyErrorAsync(
                            new Exception($"Health check failed with status {result.Status}"),
                            "System Health Check",
                            new { UnhealthyChecks = unhealthyChecks });
                    }
                }

                await Task.Delay(TimeSpan.FromSeconds(monitoringInterval), stoppingToken);
            }
            catch (Exception ex) when (ex is not OperationCanceledException || !stoppingToken.IsCancellationRequested)
            {
                _logger.LogError(ex, "Error in health check monitoring service");
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }
    }
}