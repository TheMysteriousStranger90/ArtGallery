using Serilog.Core;
using Serilog.Events;

namespace ArtGallery.WebAPI.Errors;

public class ErrorAlertSink : ILogEventSink
{
    private readonly string _webhookUrl;
    private readonly HttpClient _httpClient;

    public ErrorAlertSink(string webhookUrl)
    {
        _webhookUrl = webhookUrl;
        _httpClient = new HttpClient();
    }

    public void Emit(LogEvent logEvent)
    {
        if (string.IsNullOrEmpty(_webhookUrl) || logEvent.Level < LogEventLevel.Error)
            return;

        try
        {
            var message = logEvent.RenderMessage();
            var exception = logEvent.Exception?.ToString();

            var payload = new
            {
                text = $"⚠️ *ERROR ALERT*: {message}",
                details = exception,
                level = logEvent.Level.ToString(),
                timestamp = logEvent.Timestamp
            };

            _ = _httpClient.PostAsJsonAsync(_webhookUrl, payload);
        }
        catch
        {
        }
    }
}