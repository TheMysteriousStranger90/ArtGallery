using ArtGallery.BlazorApp.Auth;
using ArtGallery.BlazorApp.Exceptions;
using ArtGallery.BlazorApp.Services.Interfaces;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;

namespace ArtGallery.BlazorApp.Services;

public class AuthService : IAuthService
{
    private readonly IClient _client;
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly ILogger<AuthService> _logger;

    public AuthService(IClient client,
        ILocalStorageService localStorage,
        AuthenticationStateProvider authStateProvider,
        ILogger<AuthService> logger)
    {
        _client = client;
        _localStorage = localStorage;
        _authStateProvider = authStateProvider;
        _logger = logger;
    }
    
    public async Task<AuthResult> Register(RegisterCommand request)
    {
        try
        {
            _logger.LogInformation("Starting registration for user: {Email}", request.Email);
            
            var response = await ApiExceptionHandler.HandleApiOperationAsync(
                async () => await _client.RegisterAsync("1.0", request),
                "Registration failed",
                _logger);
            
            _logger.LogInformation("Registration API call completed successfully for user: {Email}", request.Email);
            
            return new AuthResult 
            { 
                IsSuccess = response != null,
                ErrorMessage = response == null ? "Registration failed" : null
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Registration failed for user: {Email}. Exception type: {ExceptionType}", 
                request.Email, ex.GetType().Name);
            return new AuthResult 
            { 
                IsSuccess = false, 
                ErrorMessage = ex.Message 
            };
        }
    }
    
  public async Task<AuthResult> Login(AuthenticateCommand request)
    {
        try
        {
            _logger.LogInformation("Starting login attempt for user: {Email}", request.Email);

            var apiResponse = await ApiExceptionHandler.HandleApiOperationAsync(
                async () => {
                    var result = await _client.AuthenticateAsync("1.0", request);
                    _logger.LogInformation("Raw API response received. Type: {Type}", result?.GetType().Name);
                    return result;
                },
                "Login failed",
                _logger);

            _logger.LogInformation("Login API call completed. ApiResponse is null: {IsNull}", apiResponse == null);

            if (apiResponse != null && !string.IsNullOrEmpty(apiResponse.Token))
            {
                _logger.LogInformation("API authentication successful for user: {Email}. Token received.", request.Email);
                _logger.LogInformation("ApiResponse properties - Token present: {HasToken}, Token length: {TokenLength}",
                    !string.IsNullOrEmpty(apiResponse.Token),
                    apiResponse.Token?.Length ?? 0);

                return new AuthResult
                {
                    IsSuccess = true,
                    Token = apiResponse.Token
                };
            }
            else
            {
                _logger.LogWarning("API authentication failed or token was empty for user: {Email}. ApiResponse type: {Type}",
                    request.Email, apiResponse?.GetType().Name);
                if (apiResponse != null) {
                     var properties = apiResponse.GetType().GetProperties();
                        foreach (var prop in properties)
                        {
                            try
                            {
                                var value = prop.GetValue(apiResponse);
                                _logger.LogInformation("ApiResponse.{PropertyName}: {Value}", prop.Name, value ?? "null");
                            }
                            catch (Exception propEx)
                            {
                                _logger.LogWarning(propEx, "Could not read property {PropertyName}", prop.Name);
                            }
                        }
                }
                return new AuthResult
                {
                    IsSuccess = false,
                    ErrorMessage = "Invalid credentials or authentication failed"
                };
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Login exception for user: {Email}. Exception type: {ExceptionType}, Stack trace: {StackTrace}",
                request.Email, ex.GetType().Name, ex.StackTrace);
            return new AuthResult
            {
                IsSuccess = false,
                ErrorMessage = $"Login error: {ex.Message}"
            };
        }
    }
    
    public async Task<bool> IsAuthenticatedAsync()
    {
        try
        {
            _logger.LogDebug("Checking authentication status");
        
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var isAuthenticated = authState.User.Identity?.IsAuthenticated ?? false;
        
            if (isAuthenticated)
            {
                _logger.LogDebug("User is authenticated according to AuthenticationStateProvider");
                return true;
            }
        
            try
            {
                var token = await _localStorage.GetItemAsync<string>("authToken");
            
                if (!string.IsNullOrEmpty(token))
                {
                    _logger.LogDebug("Token found in localStorage");
                    return true;
                }
            
                _logger.LogDebug("No token found in localStorage");
                return false;
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("JavaScript interop"))
            {
                _logger.LogDebug("In prerendering mode, can't access localStorage");
                return false;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error checking authentication status");
            return false;
        }
    }
    
    public async Task Logout()
    {
        try
        {
            _logger.LogInformation("Starting logout process");
            await _localStorage.RemoveItemAsync("authToken");
            
            if (_authStateProvider is CustomAuthStateProvider customProvider)
            {
                customProvider.NotifyUserLogout();
                _logger.LogInformation("User logged out successfully");
            }
            else
            {
                _logger.LogWarning("Could not notify logout - AuthStateProvider is not CustomAuthStateProvider");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during logout");
        }
    }
}