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
                _logger.LogInformation("Attempting login for email: {Email}", loginViewModel.Email);

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

                _logger.LogWarning("Login failed - no token received for email: {Email}", loginViewModel.Email);
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
                _logger.LogInformation("Attempting registration for email: {Email}", registerViewModel.Email);

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
                    _logger.LogInformation("Registration successful for email: {Email}", registerViewModel.Email);

                    await _authStateProvider.SetUserAuthenticatedAsync(response.Token);
                    AuthenticationStateChanged?.Invoke(true);

                    return true;
                }

                _logger.LogWarning("Registration failed - no token received for email: {Email}",
                    registerViewModel.Email);
                return false;
            }
            catch (ApiException ex) when (ex.StatusCode == 400)
            {
                _logger.LogWarning("Invalid registration data for email: {Email} - {Error}",
                    registerViewModel.Email, ex.Message);
                throw;
            }
            catch (ApiException ex) when (ex.StatusCode == 409)
            {
                _logger.LogWarning("Email already exists: {Email}", registerViewModel.Email);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during registration for email: {Email}", registerViewModel.Email);
                throw;
            }
        }

        public async Task LogoutAsync()
        {
            try
            {
                await _authStateProvider.SetUserLoggedOutAsync();
                AuthenticationStateChanged?.Invoke(false);
                _logger.LogInformation("User logged out successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during logout");
                throw;
            }
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

        public async Task<bool> MicrosoftAuthAsync(string accessToken, string returnUrl = "/")
        {
            try
            {
                _logger.LogInformation("Attempting Microsoft authentication with token length: {TokenLength}",
                    accessToken?.Length ?? 0);

                var request = new ExternalAuthRequest
                {
                    Provider = "Microsoft",
                    AccessToken = accessToken,
                    ReturnUrl = returnUrl
                };

                _logger.LogInformation("Sending Microsoft auth request to API");

                var response = await _client.MicrosoftAuthAsync("1.0", request);

                if (response != null && !string.IsNullOrEmpty(response.Token))
                {
                    await _authStateProvider.SetUserAuthenticatedAsync(response.Token);
                    AuthenticationStateChanged?.Invoke(true);
                    _logger.LogInformation("Microsoft authentication successful");
                    return true;
                }

                _logger.LogWarning("Microsoft authentication failed - no token received");
                return false;
            }
            catch (ApiException ex)
            {
                _logger.LogError(
                    "Microsoft authentication API exception - StatusCode: {StatusCode}, Content: {Content}",
                    ex.StatusCode, ex.Response);

                if (!string.IsNullOrEmpty(ex.Response))
                {
                    try
                    {
                        var errorDoc = System.Text.Json.JsonDocument.Parse(ex.Response);
                        var errorText = errorDoc.RootElement.GetRawText();
                        _logger.LogError("Detailed error response: {ErrorResponse}", errorText);
                    }
                    catch (Exception parseEx)
                    {
                        _logger.LogWarning(parseEx, "Could not parse error response as JSON");
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error during Microsoft authentication");
                return false;
            }
        }

        public async Task<string> GetTokenAsync()
        {
            try
            {
                return await _tokenService.GetTokenAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting token");
                return string.Empty;
            }
        }

        public async Task<string> GetUserNameAsync()
        {
            try
            {
                return await _tokenService.GetClaimValueAsync("unique_name");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user name");
                return string.Empty;
            }
        }

        public async Task<string> GetUserEmailAsync()
        {
            try
            {
                return await _tokenService.GetClaimValueAsync("email");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user email");
                return string.Empty;
            }
        }
    }
}