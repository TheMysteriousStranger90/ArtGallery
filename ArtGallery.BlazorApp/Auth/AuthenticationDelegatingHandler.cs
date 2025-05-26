using System.Net.Http.Headers;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace ArtGallery.BlazorApp.Auth;

public class AuthenticationDelegatingHandler : DelegatingHandler
{
    private readonly IServiceProvider _serviceProvider;
    
    public AuthenticationDelegatingHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            var authStateProvider = _serviceProvider.GetService<AuthenticationStateProvider>();
            if (authStateProvider != null)
            {
                var authState = await authStateProvider.GetAuthenticationStateAsync();
                var user = authState.User;
                
                if (user.Identity?.IsAuthenticated == true)
                {
                    var tokenClaim = user.FindFirst("access_token") ?? user.FindFirst("token");
                    if (tokenClaim != null)
                    {
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenClaim.Value);
                    }
                    else
                    {
                        var localStorage = _serviceProvider.GetService<ILocalStorageService>();
                        if (localStorage != null)
                        {
                            var token = await localStorage.GetItemAsync<string>("authToken");
                            if (!string.IsNullOrEmpty(token))
                            {
                                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                            }
                        }
                    }
                }
            }
        }
        catch (InvalidOperationException)
        {
        }
        catch (Exception)
        {
        }
        
        return await base.SendAsync(request, cancellationToken);
    }
}