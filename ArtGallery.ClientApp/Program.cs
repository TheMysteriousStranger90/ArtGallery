using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using ArtGallery.ClientApp;
using ArtGallery.ClientApp.Services;
using ArtGallery.ClientApp.Services.Interfaces;
using ArtGallery.ClientApp.Auth;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Logging
builder.Logging.SetMinimumLevel(LogLevel.Information);

// Add Blazored LocalStorage
builder.Services.AddBlazoredLocalStorage();

// Register services
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<AuthenticationMessageHandler>();

// Register Authentication State Provider
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => 
    provider.GetRequiredService<CustomAuthenticationStateProvider>());

// Add Authorization
builder.Services.AddAuthorizationCore();

// Register HttpClient with authentication handler
builder.Services.AddHttpClient<IClient, Client>("ApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:8081/");
    client.Timeout = TimeSpan.FromSeconds(30);
}).AddHttpMessageHandler<AuthenticationMessageHandler>();

// Register generated NSwag client
builder.Services.AddScoped<IClient>(sp =>
{
    var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
    var httpClient = httpClientFactory.CreateClient("ApiClient");
    return new Client("https://localhost:8081/", httpClient);
});

// Register Authentication service (now uses IClient directly)
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

// Default HttpClient for other purposes
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();