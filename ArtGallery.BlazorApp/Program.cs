using ArtGallery.BlazorApp.Auth;
using ArtGallery.BlazorApp.Components;
using ArtGallery.BlazorApp.Services;
using ArtGallery.BlazorApp.Services.Interfaces;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazoredLocalStorage();

// Add authentication support
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(); 
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();

// Add authentication services
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<AuthenticationDelegatingHandler>();

// Get base URL from configuration with better error handling
var baseUrlString = builder.Configuration["ApiSettings:BaseUrl"];
if (string.IsNullOrEmpty(baseUrlString))
{
    var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();
    logger.LogError("ApiSettings:BaseUrl is not configured in appsettings.json");
    baseUrlString = "https://localhost:8081"; // Fallback URL
}

try
{
    // Register named HttpClient with authentication handler
    builder.Services.AddHttpClient("ApiClient", client =>
    {
        client.BaseAddress = new Uri(baseUrlString);
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        client.DefaultRequestHeaders.Add("api-version", "1.0");
        client.Timeout = TimeSpan.FromSeconds(30);
    }).AddHttpMessageHandler<AuthenticationDelegatingHandler>();

    // Register the API client using the named HttpClient
    builder.Services.AddScoped<IClient>(serviceProvider =>
    {
        try
        {
            var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            var httpClient = httpClientFactory.CreateClient("ApiClient");
            
            return new Client(baseUrlString, httpClient);
        }
        catch (Exception ex)
        {
            var logger = serviceProvider.GetRequiredService<ILogger<IClient>>();
            logger.LogError(ex, "Error creating API client");
            throw;
        }
    });
}
catch (Exception ex)
{
    var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Error configuring HTTP client services");
    throw;
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); 
app.UseAuthentication(); 
app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();