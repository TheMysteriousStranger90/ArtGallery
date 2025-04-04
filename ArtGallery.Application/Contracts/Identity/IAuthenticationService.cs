using ArtGallery.Application.Models.Authentication;
using ArtGallery.Domain.Entities;

namespace ArtGallery.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
        Task<string> GenerateTokenAsync(ApplicationUser user);
    }
}
