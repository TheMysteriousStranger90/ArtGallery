using System.Security.Claims;

namespace ArtGallery.Application.Contracts;

public interface ILoggedInUserService
{
    string UserId { get; }
    string UserName { get; }
    string Email { get; }
    IEnumerable<string> Roles { get; }
    bool IsAuthenticated { get; }
    string IpAddress { get; }
    string UserAgent { get; }
    bool IsInRole(string roleName);
    bool IsInAnyRole(params string[] roleNames);
    bool HasClaim(string claimType, string claimValue);
    string GetClaimValue(string claimType);
    IEnumerable<Claim> GetAllClaims();
    Dictionary<string, string> GetRequestHeaders();
    DateTime? GetTokenExpirationTime();
    int GetTokenTimeRemaining();
}