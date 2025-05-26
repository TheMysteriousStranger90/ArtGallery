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
            
            // Call the API and log the raw response
            var authResult = await ApiExceptionHandler.HandleApiOperationAsync(
                async () => {
                    var result = await _client.AuthenticateAsync("1.0", request);
                    _logger.LogInformation("Raw API response received. Type: {Type}", result?.GetType().Name);
                    return result;
                },
                "Login failed",
                _logger);
        
            _logger.LogInformation("Login API call completed. AuthResult is null: {IsNull}", authResult == null);
            
            if (authResult != null)
            {
                // Log all properties of the auth result for debugging
                _logger.LogInformation("AuthResult properties - Token present: {HasToken}, Token length: {TokenLength}", 
                    !string.IsNullOrEmpty(authResult.Token), 
                    authResult.Token?.Length ?? 0);
                
                if (!string.IsNullOrEmpty(authResult.Token))
                {
                    try
                    {
                        _logger.LogInformation("Saving token to localStorage for user: {Email}", request.Email);
                        await _localStorage.SetItemAsync("authToken", authResult.Token);
                        
                        _logger.LogInformation("Notifying authentication state provider for user: {Email}", request.Email);
                        
                        // Check if the auth state provider is of the expected type
                        if (_authStateProvider is CustomAuthStateProvider customProvider)
                        {
                            customProvider.NotifyUserAuthentication(authResult.Token);
                            _logger.LogInformation("Successfully notified CustomAuthStateProvider");
                        }
                        else
                        {
                            _logger.LogWarning("AuthStateProvider is not CustomAuthStateProvider. Type: {Type}", 
                                _authStateProvider.GetType().Name);
                        }
                        
                        _logger.LogInformation("Login successful for user: {Email}", request.Email);
                        return new AuthResult 
                        { 
                            IsSuccess = true,
                            Token = authResult.Token
                        };
                    }
                    catch (Exception storageEx)
                    {
                        _logger.LogError(storageEx, "Error saving token or notifying auth provider for user: {Email}", 
                            request.Email);
                        return new AuthResult 
                        { 
                            IsSuccess = false, 
                            ErrorMessage = $"Authentication successful but failed to save session: {storageEx.Message}"
                        };
                    }
                }
                else
                {
                    _logger.LogWarning("Token is null or empty for user: {Email}. AuthResult type: {Type}", 
                        request.Email, authResult.GetType().Name);
                    
                    // Log all properties of authResult for debugging
                    var properties = authResult.GetType().GetProperties();
                    foreach (var prop in properties)
                    {
                        try
                        {
                            var value = prop.GetValue(authResult);
                            _logger.LogInformation("AuthResult.{PropertyName}: {Value}", prop.Name, value ?? "null");
                        }
                        catch (Exception propEx)
                        {
                            _logger.LogWarning(propEx, "Could not read property {PropertyName}", prop.Name);
                        }
                    }
                }
            }
            else
            {
                _logger.LogWarning("AuthResult is null for user: {Email}", request.Email);
            }
        
            return new AuthResult 
            { 
                IsSuccess = false, 
                ErrorMessage = "Invalid credentials or authentication failed" 
            };
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