using ArtGallery.ClientApp.ViewModels;

namespace ArtGallery.ClientApp.Services.Interfaces;

public interface IAuthenticationService
{
    event Action<bool> AuthenticationStateChanged;
    Task<bool> LoginAsync(LoginViewModel loginViewModel);
    Task<bool> RegisterAsync(RegisterViewModel registerViewModel);
    Task LogoutAsync();
    Task<bool> IsAuthenticatedAsync();
    Task<string> GetTokenAsync();
    Task<string> GetUserNameAsync();
    Task<string> GetUserEmailAsync();
}