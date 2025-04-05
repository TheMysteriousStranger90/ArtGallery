namespace ArtGallery.BlazorApp.Services.Interfaces;

public interface IAuthService
{
    Task<RegistrationResponse> Register(RegistrationRequest request);
    Task<bool> Login(AuthenticationRequest request);
    Task Logout();
}