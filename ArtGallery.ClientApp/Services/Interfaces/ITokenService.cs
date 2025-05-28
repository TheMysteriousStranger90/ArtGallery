using System.Security.Claims;

namespace ArtGallery.ClientApp.Services.Interfaces;

public interface ITokenService
{
    Task<string> GetTokenAsync();
    Task SetTokenAsync(string token);
    Task RemoveTokenAsync();
    Task<bool> IsTokenValidAsync();
    Task<ClaimsPrincipal> GetClaimsPrincipalAsync();
    Task<string> GetClaimValueAsync(string claimType);
}