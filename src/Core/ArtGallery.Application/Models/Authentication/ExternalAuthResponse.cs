namespace ArtGallery.Application.Models.Authentication;

public class ExternalAuthResponse
{
    public string Id { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
    public bool IsNewUser { get; set; }
}