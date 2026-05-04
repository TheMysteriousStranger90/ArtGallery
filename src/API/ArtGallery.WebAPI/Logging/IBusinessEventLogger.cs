namespace ArtGallery.WebAPI.Logging;

public interface IBusinessEventLogger
{
    void LogUserAction(string userId, string action, object details = null);
    void LogBusinessEvent(string eventType, string description, object details = null);
    void LogSecurityEvent(string eventType, string userId, string description, object details = null);
}