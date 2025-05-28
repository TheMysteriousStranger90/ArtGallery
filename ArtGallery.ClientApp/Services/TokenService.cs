using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ArtGallery.ClientApp.Services.Interfaces;
using Microsoft.JSInterop;

namespace ArtGallery.ClientApp.Services;

public class TokenService : ITokenService
{
    private readonly IJSRuntime _jsRuntime;
    private const string TokenKey = "authToken";

    public TokenService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<string> GetTokenAsync()
    {
        try
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", TokenKey) ?? string.Empty;
        }
        catch
        {
            return string.Empty;
        }
    }

    public async Task SetTokenAsync(string token)
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", TokenKey, token);
    }

    public async Task RemoveTokenAsync()
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", TokenKey);
    }

    public async Task<bool> IsTokenValidAsync()
    {
        var token = await GetTokenAsync();

        if (string.IsNullOrEmpty(token))
            return false;

        try
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwt = jwtHandler.ReadJwtToken(token);

            return jwt.ValidTo > DateTime.UtcNow;
        }
        catch
        {
            return false;
        }
    }

    public async Task<ClaimsPrincipal> GetClaimsPrincipalAsync()
    {
        var token = await GetTokenAsync();

        if (string.IsNullOrEmpty(token))
            return new ClaimsPrincipal();

        try
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwt = jwtHandler.ReadJwtToken(token);

            var claims = jwt.Claims.ToList();
            var identity = new ClaimsIdentity(claims, "jwt");

            return new ClaimsPrincipal(identity);
        }
        catch
        {
            return new ClaimsPrincipal();
        }
    }

    public async Task<string> GetClaimValueAsync(string claimType)
    {
        var principal = await GetClaimsPrincipalAsync();
        return principal.FindFirst(claimType)?.Value ?? string.Empty;
    }
}