using ArtGallery.ClientApp.Models;
using ArtGallery.ClientApp.Services.Interfaces;
using ArtGallery.ClientApp.ViewModels;
using ArtGallery.ClientApp.Auth;

namespace ArtGallery.ClientApp.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IClient _client;
        private readonly ITokenService _tokenService;
        private readonly CustomAuthenticationStateProvider _authStateProvider;
        private readonly ILogger<AuthenticationService> _logger;

        public event Action<bool>? AuthenticationStateChanged;

        public AuthenticationService(
            IClient client,
            ITokenService tokenService,
            CustomAuthenticationStateProvider authStateProvider,
            ILogger<AuthenticationService> logger)
        {
            _client = client;
            _tokenService = tokenService;
            _authStateProvider = authStateProvider;
            _logger = logger;
        }

        public async Task<bool> LoginAsync(LoginViewModel loginViewModel)
        {
            try
            {
                var command = new AuthenticateCommand
                {
                    Email = loginViewModel.Email,
                    Password = loginViewModel.Password
                };

                var response = await _client.AuthenticateAsync("1.0", command);
                
                if (response != null && !string.IsNullOrEmpty(response.Token))
                {
                    await _authStateProvider.SetUserAuthenticatedAsync(response.Token);
                    AuthenticationStateChanged?.Invoke(true);
                    _logger.LogInformation("Login successful for email: {Email}", loginViewModel.Email);
                    return true;
                }

                return false;
            }
            catch (ApiException ex) when (ex.StatusCode == 401)
            {
                _logger.LogWarning("Invalid credentials for email: {Email}", loginViewModel.Email);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login for email: {Email}", loginViewModel.Email);
                return false;
            }
        }

        public async Task<bool> RegisterAsync(RegisterViewModel registerViewModel)
        {
            try
            {
                var command = new RegisterCommand
                {
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    Email = registerViewModel.Email,
                    Password = registerViewModel.Password,
                    ConfirmPassword = registerViewModel.ConfirmPassword
                };

                var response = await _client.RegisterAsync("1.0", command);
                
                if (response != null && !string.IsNullOrEmpty(response.Token))
                {
                    await _authStateProvider.SetUserAuthenticatedAsync(response.Token);
                    AuthenticationStateChanged?.Invoke(true);
                    _logger.LogInformation("Registration successful for email: {Email}", registerViewModel.Email);
                    return true;
                }

                return false;
            }
            catch (ApiException ex) when (ex.StatusCode == 400)
            {
                _logger.LogWarning("Invalid registration data for email: {Email}", registerViewModel.Email);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during registration for email: {Email}", registerViewModel.Email);
                return false;
            }
        }

        public async Task LogoutAsync()
        {
            await _authStateProvider.SetUserLoggedOutAsync();
            AuthenticationStateChanged?.Invoke(false);
            _logger.LogInformation("User logged out");
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            try
            {
                return await _tokenService.IsTokenValidAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking authentication status");
                return false;
            }
        }

        public async Task<string> GetTokenAsync()
        {
            return await _tokenService.GetTokenAsync();
        }

        public async Task<string> GetUserNameAsync()
        {
            return await _tokenService.GetClaimValueAsync("unique_name");
        }

        public async Task<string> GetUserEmailAsync()
        {
            return await _tokenService.GetClaimValueAsync("email");
        }
    }
}