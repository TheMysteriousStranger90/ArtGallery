namespace ArtGallery.ClientApp.Services;

public enum ToastLevel { Info, Success, Warning, Error }

public record ToastMessage(string Message, ToastLevel Level, string Id = "");

public class ToastService
{
    private readonly List<ToastMessage> _messages = new();
    public IReadOnlyList<ToastMessage> Messages => _messages;
    public event Action? OnChange;

    public void Show(string message, ToastLevel level = ToastLevel.Info)
    {
        var toast = new ToastMessage(message, level, Guid.NewGuid().ToString());
        _messages.Add(toast);
        OnChange?.Invoke();
        // Auto-dismiss after 4 s (timer fires independently)
        _ = Task.Run(async () =>
        {
            await Task.Delay(4000);
            Dismiss(toast.Id);
        });
    }

    public void Success(string message) => Show(message, ToastLevel.Success);
    public void Error(string message)   => Show(message, ToastLevel.Error);
    public void Warning(string message) => Show(message, ToastLevel.Warning);

    public void Dismiss(string id)
    {
        _messages.RemoveAll(m => m.Id == id);
        OnChange?.Invoke();
    }
}
