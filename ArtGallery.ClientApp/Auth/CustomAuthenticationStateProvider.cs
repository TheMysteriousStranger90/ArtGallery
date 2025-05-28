using Microsoft.AspNetCore.Components.Authorization;
using ArtGallery.ClientApp.Services.Interfaces;
using System.Security.Claims;
using System.Text.Json;

namespace ArtGallery.ClientApp.Auth
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ITokenService _tokenService;
        private readonly ILogger<CustomAuthenticationStateProvider> _logger;

        public CustomAuthenticationStateProvider(
            ITokenService tokenService,
            ILogger<CustomAuthenticationStateProvider> logger)
        {
            _tokenService = tokenService;
            _logger = logger;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var token = await _tokenService.GetTokenAsync();

                if (string.IsNullOrWhiteSpace(token))
                {
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }

                var isValid = await _tokenService.IsTokenValidAsync();
                if (!isValid)
                {
                    await _tokenService.RemoveTokenAsync();
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }

                var claims = ParseTokenClaims(token);
                var identity = new ClaimsIdentity(claims, "jwt");
                var user = new ClaimsPrincipal(identity);

                return new AuthenticationState(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting authentication state");
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }

        public async Task SetUserAuthenticatedAsync(string token)
        {
            try
            {
                await _tokenService.SetTokenAsync(token);
                var claims = ParseTokenClaims(token);
                var identity = new ClaimsIdentity(claims, "jwt");
                var user = new ClaimsPrincipal(identity);
                var authState = Task.FromResult(new AuthenticationState(user));
                NotifyAuthenticationStateChanged(authState);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error setting user authenticated");
            }
        }

        public async Task SetUserLoggedOutAsync()
        {
            try
            {
                await _tokenService.RemoveTokenAsync();
                var anonUser = new ClaimsPrincipal(new ClaimsIdentity());
                var authState = Task.FromResult(new AuthenticationState(anonUser));
                NotifyAuthenticationStateChanged(authState);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error setting user logged out");
            }
        }

        private IEnumerable<Claim> ParseTokenClaims(string jwt)
        {
            var claims = new List<Claim>();
            
            try
            {
                var payload = jwt.Split('.')[1];
                var jsonBytes = ParseBase64WithoutPadding(payload);
                var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

                if (keyValuePairs == null) return claims;

                // Handle roles
                if (keyValuePairs.TryGetValue(ClaimTypes.Role, out object? roles))
                {
                    if (roles != null)
                    {
                        var rolesString = roles.ToString();
                        if (!string.IsNullOrEmpty(rolesString))
                        {
                            if (rolesString.Trim().StartsWith("["))
                            {
                                var parsedRoles = JsonSerializer.Deserialize<string[]>(rolesString);
                                if (parsedRoles != null)
                                {
                                    foreach (var parsedRole in parsedRoles)
                                    {
                                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                                    }
                                }
                            }
                            else
                            {
                                claims.Add(new Claim(ClaimTypes.Role, rolesString));
                            }
                        }
                    }
                    keyValuePairs.Remove(ClaimTypes.Role);
                }

                // Handle other standard claims
                foreach (var kvp in keyValuePairs)
                {
                    var claimType = kvp.Key switch
                    {
                        "sub" => ClaimTypes.NameIdentifier,
                        "email" => ClaimTypes.Email,
                        "name" => ClaimTypes.Name,
                        "unique_name" => ClaimTypes.Name,
                        "given_name" => ClaimTypes.GivenName,
                        "family_name" => ClaimTypes.Surname,
                        _ => kvp.Key
                    };

                    var value = kvp.Value?.ToString();
                    if (!string.IsNullOrEmpty(value))
                    {
                        claims.Add(new Claim(claimType, value));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error parsing token claims");
            }

            return claims;
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}