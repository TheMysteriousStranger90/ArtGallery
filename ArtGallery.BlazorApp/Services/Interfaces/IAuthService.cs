using ArtGallery.BlazorApp.Auth;

namespace ArtGallery.BlazorApp.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResult> Register(RegisterCommand request);
    Task<AuthResult> Login(AuthenticateCommand request);
    Task<bool> IsAuthenticatedAsync();
    Task Logout();
}