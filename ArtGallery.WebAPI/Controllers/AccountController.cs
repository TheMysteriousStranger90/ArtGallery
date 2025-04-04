using ArtGallery.Application.Contracts.Identity;
using ArtGallery.Application.Models.Authentication;
using ArtGallery.WebAPI.Errors;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace ArtGallery.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[ApiVersion("1.0")]
public class AccountController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly ILogger<AccountController> _logger;

    public AccountController(IAuthenticationService authenticationService, ILogger<AccountController> logger)
    {
        _authenticationService = authenticationService;
        _logger = logger;
    }

    /// <summary>
    /// Registers a new user
    /// </summary>
    /// <param name="request">User registration details</param>
    /// <response code="200">Returns the newly registered user ID</response>
    /// <response code="400">If the registration data is invalid</response>
    /// <response code="429">Too many requests</response>
    [HttpPost("register")]
    [EnableRateLimiting("registration")]
    [ProducesResponseType(typeof(RegistrationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
    public async Task<ActionResult<RegistrationResponse>> RegisterAsync([FromBody] RegistrationRequest request)
    {
        _logger.LogInformation("Attempting to register user: {Email}", request.Email);

        var response = await _authenticationService.RegisterAsync(request);
        _logger.LogInformation("User registered successfully: {Email}", request.Email);
        return Ok(response);
    }


    /// <summary>
    /// Authenticates a user and returns a JWT token
    /// </summary>
    /// <param name="request">User credentials</param>
    /// <response code="200">Returns the user data with access token</response>
    /// <response code="401">If authentication fails</response>
    /// <response code="429">Too many requests</response>
    [HttpPost("authenticate")]
    [EnableRateLimiting("authentication")]
    [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync([FromBody] AuthenticationRequest request)
    {
        _logger.LogInformation("Login attempt for user: {Email}", request.Email);

        var response = await _authenticationService.AuthenticateAsync(request);
        _logger.LogInformation("User authenticated successfully: {Email}", request.Email);
        return Ok(response);
    }
}