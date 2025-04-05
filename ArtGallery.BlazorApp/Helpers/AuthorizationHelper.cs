using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace ArtGallery.BlazorApp.Helpers;

public static class AuthorizationHelper
{
    public static bool IsInRole(this AuthenticationState authState, string role)
    {
        return authState?.User?.IsInRole(role) ?? false;
    }
    
    public static bool IsAdmin(this AuthenticationState authState)
    {
        return authState?.User?.IsInRole("Administrator") ?? false;
    }
    
    public static string GetUserId(this AuthenticationState authState)
    {
        return authState?.User?.FindFirstValue("uid");
    }
    
    public static string GetUserName(this AuthenticationState authState)
    {
        return authState?.User?.FindFirstValue(ClaimTypes.Name);
    }
    
    public static string GetUserEmail(this AuthenticationState authState)
    {
        return authState?.User?.FindFirstValue(ClaimTypes.Email);
    }
}