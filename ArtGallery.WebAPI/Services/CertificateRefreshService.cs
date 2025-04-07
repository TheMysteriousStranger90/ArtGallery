namespace ArtGallery.WebAPI.Services;

public class CertificateRefreshService : BackgroundService
{
    private readonly TlsCertificateLoader.TlsCertificateLoader _tlsCertificateLoader;
    private readonly ILogger<CertificateRefreshService> _logger;
    private readonly TimeSpan _refreshInterval = TimeSpan.FromHours(12);

    public CertificateRefreshService(
        TlsCertificateLoader.TlsCertificateLoader tlsCertificateLoader,
        ILogger<CertificateRefreshService> logger)
    {
        _tlsCertificateLoader = tlsCertificateLoader;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _tlsCertificateLoader.RefreshDefaultCertificates();
                _logger.LogInformation("TLS certificates refreshed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error refreshing TLS certificates");
            }

            await Task.Delay(_refreshInterval, stoppingToken);
        }
    }
}