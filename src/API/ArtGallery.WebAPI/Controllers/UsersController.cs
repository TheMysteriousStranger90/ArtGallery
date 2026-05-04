using System.Security.Claims;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Features.Users.Commands;
using ArtGallery.Application.Features.Users.Queries;
using ArtGallery.Application.Models.Users;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IMediator mediator, ILogger<UsersController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Admin only - Returns list of all registered users
        /// </summary>
        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var adminId = User.FindFirstValue("uid");
            _logger.LogInformation("Admin {AdminId} requesting all users", adminId);

            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Admin only - Get user details by ID
        /// </summary>
        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDetailDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<UserDetailDto>> GetUserById(string id)
        {
            _logger.LogInformation("Requesting user details for ID: {UserId}", id);

            var query = new GetUserByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Get current user profile
        /// </summary>
        [Authorize]
        [HttpGet("me")]
        [ProducesResponseType(typeof(UserProfileDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserProfileDto>> GetCurrentUser()
        {
            var userId = User.FindFirstValue("uid");
            _logger.LogInformation("User {UserId} requesting their profile", userId);

            var query = new GetCurrentUserQuery { UserId = userId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Admin only - Update user details
        /// </summary>
        [Authorize(Policy = "RequireAdminRole")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserRequest request)
        {
            _logger.LogInformation("Updating user with ID: {UserId}", id);

            var command = new UpdateUserCommand
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.UserName
            };

            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(new { message = result.Message });
        }

        /// <summary>
        /// Admin only - Assign role to user
        /// </summary>
        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("{id}/roles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> AssignRoleToUser(string id, [FromBody] AssignRoleRequest request)
        {
            _logger.LogInformation("Assigning role {RoleName} to user {UserId}", request.RoleName, id);

            var command = new AssignRoleCommand
            {
                UserId = id,
                RoleName = request.RoleName
            };

            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(new
            {
                message = result.Message,
                roles = result.Roles
            });
        }

        /// <summary>
        /// Admin only - Remove role from user
        /// </summary>
        [Authorize(Policy = "RequireAdminRole")]
        [HttpDelete("{id}/roles/{roleName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> RemoveRoleFromUser(string id, string roleName)
        {
            _logger.LogInformation("Removing role {RoleName} from user {UserId}", roleName, id);

            var command = new RemoveRoleCommand
            {
                UserId = id,
                RoleName = roleName
            };

            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(new
            {
                message = result.Message,
                roles = result.Roles
            });
        }
    }
}