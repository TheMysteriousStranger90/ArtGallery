using Serilog;
using System.Net.Http.Json;

namespace ArtGallery.WebAPI.Errors;

public class ErrorNotifier : IErrorNotifier
{
    private readonly HttpClient _httpClient;
    private readonly string _webhookUrl;
    private readonly Serilog.ILogger _logger;
    
    public ErrorNotifier(IConfiguration configuration, Serilog.ILogger logger)
    {
        _httpClient = new HttpClient();
        _webhookUrl = configuration["Monitoring:AlertWebhook"];
        _logger = logger;
    }
    
    public async Task NotifyErrorAsync(Exception exception, string context, object additionalData = null)
    {
        try
        {
            if (string.IsNullOrEmpty(_webhookUrl))
            {
                _logger.Warning("No alert webhook configured. Skipping alert notification.");
                return;
            }
            
            var alert = new
            {
                Application = "ArtGalleryAPI",
                Context = context,
                ErrorMessage = exception.Message,
                StackTrace = exception.StackTrace,
                AdditionalData = additionalData,
                Timestamp = DateTime.UtcNow
            };
            
            await _httpClient.PostAsJsonAsync(_webhookUrl, alert);
            
            _logger.Information("Error alert notification sent for {Context}", context);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Failed to send error alert notification");
        }
    }
}