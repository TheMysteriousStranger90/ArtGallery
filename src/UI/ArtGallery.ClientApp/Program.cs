using ArtGallery.ClientApp.Auth;
using ArtGallery.ClientApp.Constants;
using ArtGallery.ClientApp.Services;
using ArtGallery.ClientApp.Services.Interfaces;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

namespace ArtGallery.ClientApp;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Logging.SetMinimumLevel(LogLevel.Warning);

        // Core Blazor services
        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddAuthorizationCore();

        // Authentication
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<AuthenticationMessageHandler>();
        builder.Services.AddScoped<CustomAuthenticationStateProvider>();
        builder.Services.AddScoped<AuthenticationStateProvider>(sp =>
            sp.GetRequiredService<CustomAuthenticationStateProvider>());

        // HTTP client with auth handler
        builder.Services.AddHttpClient<IClient, Client>("ApiClient", client =>
        {
            client.BaseAddress = new Uri(Const.DefaultApiUrl);
            client.Timeout = TimeSpan.FromSeconds(30);
        }).AddHttpMessageHandler<AuthenticationMessageHandler>();

        // NSwag generated client
        builder.Services.AddScoped<IClient>(sp =>
        {
            var factory = sp.GetRequiredService<IHttpClientFactory>();
            var http = factory.CreateClient("ApiClient");
            return new Client(Const.DefaultApiUrl, http);
        });

        // Domain services
        builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
        builder.Services.AddScoped<IPaintingService, PaintingService>();
        builder.Services.AddScoped<IArtistService, ArtistService>();
        builder.Services.AddScoped<IUsersService, UsersService>();
        builder.Services.AddScoped<IExhibitionsService, ExhibitionsService>();

        // UI state services
        builder.Services.AddScoped<FavoritesStateService>();
        builder.Services.AddScoped<ToastService>();

        // Default HttpClient for app assets
        builder.Services.AddScoped(_ => new HttpClient
        {
            BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
        });

        var app = builder.Build();
        var jsRuntime = app.Services.GetRequiredService<IJSRuntime>();
        await Const.InitializeFromJsAsync(jsRuntime);

        await app.RunAsync();
    }
}
