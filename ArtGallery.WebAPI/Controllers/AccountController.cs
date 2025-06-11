using System.Text.Json;
using ArtGallery.Application.Features.Authentication.Commands;
using ArtGallery.Application.Models.Authentication;
using ArtGallery.WebAPI.Errors;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace ArtGallery.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [AllowAnonymous]
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
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(
            [FromBody] AuthenticateCommand command)
        {
            _logger.LogInformation("Authentication request received for email: {Email}", command.Email);

            var response = await _mediator.Send(command);

            _logger.LogInformation("User authenticated successfully: {Email}", command.Email);
            return Ok(response);
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
            try
            {
                if (request == null)
                {
                    _logger.LogError("Request is null");
                    return BadRequest(new ErrorResponse { Errors = new[] { "Request cannot be null" } });
                }

                _logger.LogInformation(
                    "Request properties - Provider: '{Provider}', HasAccessToken: {HasToken}, TokenLength: {TokenLength}",
                    request.Provider, !string.IsNullOrEmpty(request.AccessToken), request.AccessToken?.Length ?? 0);

                var errors = new List<string>();

                if (string.IsNullOrEmpty(request.AccessToken))
                {
                    errors.Add("Access token is required");
                }

                if (string.IsNullOrEmpty(request.Provider))
                {
                    errors.Add("Provider is required");
                }
                else if (request.Provider != "Microsoft")
                {
                    errors.Add("Invalid provider");
                }

                if (errors.Any())
                {
                    _logger.LogWarning("Validation errors: {Errors}", string.Join(", ", errors));
                    return BadRequest(new ErrorResponse { Errors = errors.ToArray() });
                }

                var microsoftClientId = _configuration["ExternalAuth:Microsoft:ClientId"];
                _logger.LogInformation("Microsoft ClientId from config: {HasClientId}",
                    !string.IsNullOrEmpty(microsoftClientId));

                if (string.IsNullOrEmpty(microsoftClientId))
                {
                    _logger.LogError("Microsoft ClientId not configured");
                    return BadRequest(
                        new ErrorResponse { Errors = new[] { "Microsoft authentication not configured" } });
                }

                _logger.LogInformation("Creating HTTP client for Microsoft Graph API call");

                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", request.AccessToken);

                _logger.LogInformation("Calling Microsoft Graph API...");

                var response = await httpClient.GetAsync("https://graph.microsoft.com/v1.0/me");

                _logger.LogInformation("Microsoft Graph API response: {StatusCode}", response.StatusCode);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    _logger.LogError("Microsoft Graph API error - Status: {StatusCode}, Content: {Content}",
                        response.StatusCode, errorContent);

                    return BadRequest(new ErrorResponse
                    {
                        Errors = new[] { $"Invalid Microsoft token: {response.StatusCode}" }
                    });
                }

                var content = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("Successfully received user info from Microsoft Graph API");

                var userInfo = JsonSerializer.Deserialize<JsonElement>(content);

                string email = null;
                if (userInfo.TryGetProperty("mail", out var mailProp) && mailProp.ValueKind == JsonValueKind.String)
                {
                    email = mailProp.GetString();
                }
                else if (userInfo.TryGetProperty("userPrincipalName", out var upnProp) &&
                         upnProp.ValueKind == JsonValueKind.String)
                {
                    email = upnProp.GetString();
                }

                if (string.IsNullOrEmpty(email))
                {
                    _logger.LogError("Could not extract email from Microsoft response");
                    return BadRequest(new ErrorResponse
                        { Errors = new[] { "Could not retrieve email from Microsoft account" } });
                }

                var command = new ExternalAuthCommand
                {
                    Provider = "Microsoft",
                    AccessToken = request.AccessToken,
                    Email = email,
                    FirstName = userInfo.TryGetProperty("givenName", out var fn) ? fn.GetString() : null,
                    LastName = userInfo.TryGetProperty("surname", out var ln) ? ln.GetString() : null,
                    ExternalId = userInfo.TryGetProperty("id", out var id) ? id.GetString() : null
                };

                var authResponse = await _mediator.Send(command);

                _logger.LogInformation("Authentication successful, returning response");
                return Ok(authResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in Microsoft auth controller method");
                return BadRequest(new ErrorResponse { Errors = new[] { ex.Message } });
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
            var providers = new[] { "Microsoft" };
            return Ok(providers);
        }
    }
}