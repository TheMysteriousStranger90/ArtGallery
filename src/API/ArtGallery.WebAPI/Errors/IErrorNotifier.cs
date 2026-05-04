namespace ArtGallery.WebAPI.Errors;

public interface IErrorNotifier
{
    Task NotifyErrorAsync(Exception exception, string context, object additionalData = null);
}