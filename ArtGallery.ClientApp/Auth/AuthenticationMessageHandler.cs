using System.Net.Http.Headers;
using ArtGallery.ClientApp.Services.Interfaces;

namespace ArtGallery.ClientApp.Auth
{
    public class AuthenticationMessageHandler : DelegatingHandler
    {
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthenticationMessageHandler> _logger;

        public AuthenticationMessageHandler(
            ITokenService tokenService,
            ILogger<AuthenticationMessageHandler> logger)
        {
            _tokenService = tokenService;
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var token = await _tokenService.GetTokenAsync();
                
                if (!string.IsNullOrEmpty(token))
                {
                    var isValid = await _tokenService.IsTokenValidAsync();
                    if (isValid)
                    {
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    else
                    {
                        _logger.LogWarning("Token is invalid, removing from storage");
                        await _tokenService.RemoveTokenAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding authorization header");
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}