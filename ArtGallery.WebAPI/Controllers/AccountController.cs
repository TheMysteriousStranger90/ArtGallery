using System.Text.Json;
using ArtGallery.Application.Features.Authentication.Commands;
using ArtGallery.Application.Models.Authentication;
using ArtGallery.WebAPI.Errors;
using Asp.Versioning;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace ArtGallery.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;

        public AccountController(IMediator mediator, ILogger<AccountController> logger, IConfiguration configuration)
        {
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="command">User registration details</param>
        /// <response code="200">Returns the newly registered user data with token</response>
        /// <response code="400">If the registration data is invalid</response>
        /// <response code="429">Too many requests</response>
        [HttpPost("register")]
        [EnableRateLimiting("registration")]
        [ProducesResponseType(typeof(RegistrationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync([FromBody] RegisterCommand command)
        {
            _logger.LogInformation("Registration request received for email: {Email}", command.Email);

            var response = await _mediator.Send(command);
            
            _logger.LogInformation("User registered successfully: {Email}", command.Email);
            return Ok(response);
        }

        /// <summary>
        /// Authenticates a user and returns a JWT token
        /// </summary>
        /// <param name="command">User credentials</param>
        /// <response code="200">Returns the user data with access token</response>
        /// <response code="401">If authentication fails</response>
        /// <response code="429">Too many requests</response>
        [HttpPost("authenticate")]
        [EnableRateLimiting("authentication")]
        [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync([FromBody] AuthenticateCommand command)
        {
            _logger.LogInformation("Authentication request received for email: {Email}", command.Email);

            var response = await _mediator.Send(command);
            
            _logger.LogInformation("User authenticated successfully: {Email}", command.Email);
            return Ok(response);
        }
        
     /// <summary>
        /// Authenticates a user using Google OAuth
        /// </summary>
        /// <param name="request">Google authentication request</param>
        /// <response code="200">Returns the user data with access token</response>
        /// <response code="400">If Google token validation fails</response>
        /// <response code="429">Too many requests</response>
        [HttpPost("google-auth")]
        [EnableRateLimiting("authentication")]
        [ProducesResponseType(typeof(ExternalAuthResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<ActionResult<ExternalAuthResponse>> GoogleAuthAsync([FromBody] ExternalAuthRequest request)
        {
            _logger.LogInformation("Google authentication request received");

            try
            {
                var googleClientId = _configuration["ExternalAuth:Google:ClientId"];
                
                if (string.IsNullOrEmpty(googleClientId))
                {
                    _logger.LogError("Google ClientId not configured");
                    return BadRequest(new ErrorResponse { Errors = new[] { "Google authentication not configured" } });
                }

                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string> { googleClientId }
                };

                var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, settings);

                var command = new ExternalAuthCommand
                {
                    Provider = "Google",
                    IdToken = request.IdToken,
                    Email = payload.Email,
                    FirstName = payload.GivenName,
                    LastName = payload.FamilyName,
                    ExternalId = payload.Subject
                };

                var response = await _mediator.Send(command);
                
                _logger.LogInformation("Google authentication successful for: {Email}", payload.Email);
                return Ok(response);
            }
            catch (InvalidJwtException ex)
            {
                _logger.LogWarning("Invalid Google JWT token: {Error}", ex.Message);
                return BadRequest(new ErrorResponse { Errors = new[] { "Invalid Google token" } });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during Google authentication");
                return BadRequest(new ErrorResponse { Errors = new[] { "Google authentication failed" } });
            }
        }

        /// <summary>
        /// Authenticates a user using Microsoft OAuth
        /// </summary>
        /// <param name="request">Microsoft authentication request</param>
        /// <response code="200">Returns the user data with access token</response>
        /// <response code="400">If Microsoft token validation fails</response>
        /// <response code="429">Too many requests</response>
        [HttpPost("microsoft-auth")]
        [EnableRateLimiting("authentication")]
        [ProducesResponseType(typeof(ExternalAuthResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<ActionResult<ExternalAuthResponse>> MicrosoftAuthAsync([FromBody] ExternalAuthRequest request)
        {
            _logger.LogInformation("Microsoft authentication request received");

            try
            {
                var microsoftClientId = _configuration["ExternalAuth:Microsoft:ClientId"];
                
                if (string.IsNullOrEmpty(microsoftClientId))
                {
                    _logger.LogError("Microsoft ClientId not configured");
                    return BadRequest(new ErrorResponse { Errors = new[] { "Microsoft authentication not configured" } });
                }

                using var httpClient = new HttpClient();
                
                httpClient.DefaultRequestHeaders.Authorization = 
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", request.AccessToken);
                
                var response = await httpClient.GetAsync("https://graph.microsoft.com/v1.0/me");
                
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Failed to validate Microsoft token. Status: {StatusCode}", response.StatusCode);
                    return BadRequest(new ErrorResponse { Errors = new[] { "Invalid Microsoft token" } });
                }

                var content = await response.Content.ReadAsStringAsync();
                var userInfo = JsonSerializer.Deserialize<JsonElement>(content);

                var command = new ExternalAuthCommand
                {
                    Provider = "Microsoft",
                    AccessToken = request.AccessToken,
                    Email = userInfo.GetProperty("mail").GetString() ?? userInfo.GetProperty("userPrincipalName").GetString(),
                    FirstName = userInfo.GetProperty("givenName").GetString(),
                    LastName = userInfo.GetProperty("surname").GetString(),
                    ExternalId = userInfo.GetProperty("id").GetString()
                };

                var authResponse = await _mediator.Send(command);
                
                _logger.LogInformation("Microsoft authentication successful for: {Email}", command.Email);
                return Ok(authResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during Microsoft authentication");
                return BadRequest(new ErrorResponse { Errors = new[] { "Microsoft authentication failed" } });
            }
        }

        /// <summary>
        /// Get external authentication providers
        /// </summary>
        /// <response code="200">Returns available external providers</response>
        [HttpGet("external-providers")]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status200OK)]
        public ActionResult<string[]> GetExternalProviders()
        {
            var providers = new[] { "Google", "Microsoft" };
            return Ok(providers);
        }
    }
}