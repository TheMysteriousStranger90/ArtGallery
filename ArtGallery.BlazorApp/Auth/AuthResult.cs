namespace ArtGallery.BlazorApp.Auth;

public class AuthResult
{
    public bool IsSuccess { get; set; }
    public string? ErrorMessage { get; set; }
    public string? Token { get; set; }
}