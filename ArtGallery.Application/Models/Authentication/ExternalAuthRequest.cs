namespace ArtGallery.Application.Models.Authentication;

public class ExternalAuthRequest
{
    public string Provider { get; set; } = string.Empty;
    public string IdToken { get; set; } = string.Empty;
    public string AccessToken { get; set; } = string.Empty;
    public string ReturnUrl { get; set; } = "/";
}