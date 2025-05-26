using ArtGallery.BlazorApp.Auth;
using ArtGallery.BlazorApp.Exceptions;
using ArtGallery.BlazorApp.Services.Interfaces;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace ArtGallery.BlazorApp.Services;

public class AuthService : IAuthService
{
    private readonly IClient _client;
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationStateProvider _authStateProvider;
    
    public AuthService(IClient client, 
        ILocalStorageService localStorage,
        AuthenticationStateProvider authStateProvider)
    {
        _client = client;
        _localStorage = localStorage;
        _authStateProvider = authStateProvider;
    }
    
    public async Task<RegistrationResponse> Register(RegisterCommand request)
    {
        return await ApiExceptionHandler.HandleApiOperationAsync(
            async () => await _client.RegisterAsync("1.0", request),
            "Registration failed");
    }
    
    public async Task<bool> Login(AuthenticateCommand request)
    {
        try
        {
            var authResult = await ApiExceptionHandler.HandleApiOperationAsync(
                async () => await _client.AuthenticateAsync("1.0", request),
                "Login failed");
        
            if (authResult != null && !string.IsNullOrEmpty(authResult.Token))
            {
                await _localStorage.SetItemAsync("authToken", authResult.Token);
                ((CustomAuthStateProvider)_authStateProvider).NotifyUserAuthentication(authResult.Token);
                return true;
            }
        
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    
    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        ((CustomAuthStateProvider)_authStateProvider).NotifyUserLogout();
    }
}