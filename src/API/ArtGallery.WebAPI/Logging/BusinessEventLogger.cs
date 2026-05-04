using Serilog;

namespace ArtGallery.WebAPI.Logging;

public class BusinessEventLogger : IBusinessEventLogger
{
    private readonly Serilog.ILogger _logger;

    public BusinessEventLogger(Serilog.ILogger logger)
    {
        _logger = logger;
    }

    public void LogUserAction(string userId, string action, object details = null)
    {
        _logger.ForContext("EventType", "BusinessEvent.UserAction")
            .ForContext("UserId", userId)
            .Information("{Action} by user {UserId} {Details}",
                action, userId, details ?? new { });
    }

    public void LogBusinessEvent(string eventType, string description, object details = null)
    {
        _logger.ForContext("EventType", $"BusinessEvent.{eventType}")
            .Information("{Description} {Details}",
                description, details ?? new { });
    }

    public void LogSecurityEvent(string eventType, string userId, string description, object details = null)
    {
        _logger.ForContext("EventType", $"SecurityEvent.{eventType}")
            .ForContext("UserId", userId)
            .Warning("{Description} for user {UserId} {Details}",
                description, userId, details ?? new { });
    }
}