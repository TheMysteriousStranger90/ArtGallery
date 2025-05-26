using ArtGallery.BlazorApp.Auth;
using ArtGallery.BlazorApp.Components;
using ArtGallery.BlazorApp.Services;
using ArtGallery.BlazorApp.Services.Interfaces;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazoredLocalStorage();

// Add authentication support
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();

// Add authentication services
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<AuthenticationDelegatingHandler>();

// Get base URL from configuration
var baseUrlString = builder.Configuration["ApiSettings:BaseUrl"];
if (string.IsNullOrEmpty(baseUrlString))
{
    throw new InvalidOperationException("ApiSettings:BaseUrl is not configured in appsettings.json");
}

// Register named HttpClient with authentication handler
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri(baseUrlString);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.DefaultRequestHeaders.Add("api-version", "1.0");
}).AddHttpMessageHandler<AuthenticationDelegatingHandler>();

// Register the API client using the named HttpClient
builder.Services.AddScoped<IClient>(serviceProvider =>
{
    var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
    var httpClient = httpClientFactory.CreateClient("ApiClient");
    
    return new Client(baseUrlString, httpClient);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();