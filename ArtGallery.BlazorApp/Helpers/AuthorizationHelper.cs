using System.Security.Claims;

namespace ArtGallery.BlazorApp.Helpers
{
    public static class AuthorizationHelper
    {
        public static string GetUserId(ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        public static string GetUserName(ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;
        }

        public static string GetUserEmail(ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;
        }

        public static string GetUserRole(ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty;
        }

        public static bool IsInRole(ClaimsPrincipal user, string role)
        {
            return user.IsInRole(role);
        }

        public static bool HasClaim(ClaimsPrincipal user, string claimType, string claimValue)
        {
            return user.HasClaim(claimType, claimValue);
        }
    }
}