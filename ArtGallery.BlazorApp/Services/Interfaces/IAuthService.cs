namespace ArtGallery.BlazorApp.Services.Interfaces;

public interface IAuthService
{
    Task<RegistrationResponse> Register(RegisterCommand request);
    Task<bool> Login(AuthenticateCommand request);
    Task Logout();
}