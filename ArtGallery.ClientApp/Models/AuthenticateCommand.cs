namespace ArtGallery.ClientApp.Models;

public class AuthenticateCommand
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}