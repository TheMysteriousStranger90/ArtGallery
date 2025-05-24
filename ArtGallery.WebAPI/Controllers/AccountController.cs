using ArtGallery.Application.Features.Authentication.Commands;
using ArtGallery.Application.Models.Authentication;
using ArtGallery.WebAPI.Errors;
using Asp.Versioning;
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

        public AccountController(IMediator mediator, ILogger<AccountController> logger)
        {
            _mediator = mediator;
            _logger = logger;
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
    }
}