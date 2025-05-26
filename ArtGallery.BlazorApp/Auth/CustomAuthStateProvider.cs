using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace ArtGallery.BlazorApp.Auth;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;
    private readonly JwtSecurityTokenHandler _tokenHandler;
    private readonly ILogger<CustomAuthStateProvider> _logger;

    public CustomAuthStateProvider(
        ILocalStorageService localStorage,
        ILogger<CustomAuthStateProvider> logger)
    {
        _localStorage = localStorage;
        _tokenHandler = new JwtSecurityTokenHandler();
        _logger = logger;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");

            if (string.IsNullOrEmpty(token))
            {
                _logger.LogDebug("No auth token found in localStorage");
                return CreateAnonymousState();
            }

            if (!_tokenHandler.CanReadToken(token))
            {
                _logger.LogWarning("Invalid JWT token format");
                await _localStorage.RemoveItemAsync("authToken");
                return CreateAnonymousState();
            }

            var jwtToken = _tokenHandler.ReadJwtToken(token);

            if (jwtToken.ValidTo.AddMinutes(-5) < DateTime.UtcNow)
            {
                _logger.LogInformation("JWT token expired or expiring soon");
                await _localStorage.RemoveItemAsync("authToken");
                return CreateAnonymousState();
            }

            var claims = jwtToken.Claims.ToList();

            claims.Add(new Claim("access_token", token));

            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            _logger.LogDebug("User authenticated from JWT token");
            return new AuthenticationState(user);
        }
        catch (InvalidOperationException ex) when (ex.Message.Contains("JavaScript interop"))
        {
            _logger.LogDebug("Cannot access localStorage during prerendering");
            return CreateAnonymousState();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error validating authentication state");

            try
            {
                await _localStorage.RemoveItemAsync("authToken");
            }
            catch
            {
            }

            return CreateAnonymousState();
        }
    }

    public async Task NotifyUserAuthentication(string token)
    {
        try
        {
            if (string.IsNullOrEmpty(token))
            {
                _logger.LogError("Cannot notify authentication with null or empty token");
                return;
            }

            if (!_tokenHandler.CanReadToken(token))
            {
                _logger.LogError("Cannot notify authentication with invalid token format");
                return;
            }

            var jwtToken = _tokenHandler.ReadJwtToken(token);

            if (jwtToken.ValidTo < DateTime.UtcNow)
            {
                _logger.LogWarning("Attempted to authenticate with expired token");
                await _localStorage.RemoveItemAsync("authToken");
                return;
            }

            var claims = jwtToken.Claims.ToList();

            claims.Add(new Claim("access_token", token));

            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);

            _logger.LogInformation("User authentication state updated");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error notifying user authentication");
            throw;
        }
    }

    public async Task NotifyUserLogout()
    {
        try
        {
            await _localStorage.RemoveItemAsync("authToken");

            var authState = Task.FromResult(CreateAnonymousState());
            NotifyAuthenticationStateChanged(authState);

            _logger.LogInformation("User logged out");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during logout notification");
            throw;
        }
    }

    private static AuthenticationState CreateAnonymousState()
    {
        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }
}