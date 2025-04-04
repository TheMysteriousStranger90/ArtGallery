using System.Security.Claims;
using ArtGallery.Application.Contracts;
using ArtGallery.Application.Contracts.Identity;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Exceptions;
using ArtGallery.Application.Features.Paintings.Queries;
using ArtGallery.Application.Models.Users;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[ApiVersion("1.0")]
public class UsersController : ControllerBase
{
    private readonly IUserManagerService _userManagerService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UsersController> _logger;

    public UsersController(
        ILogger<UsersController> logger, 
        IUserManagerService userManagerService,
        IUnitOfWork unitOfWork)
    {
        _userManagerService = userManagerService;
        _unitOfWork = unitOfWork;
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
        _logger.LogInformation("Admin {AdminId} requesting all users", User.FindFirstValue("uid"));

        var users = await _userManagerService.GetAllUsersAsync();
        var userDtos = new List<UserDto>();

        foreach (var user in users)
        {
            var favoritePaintings = await _unitOfWork.UserFavoritesRepository.GetUserFavoritePaintingsAsync(user.Id);
            var favoriteArtists = await _unitOfWork.UserFavoritesRepository.GetUserFavoriteArtistsAsync(user.Id);
        
            var roles = await _userManagerService.GetUserRolesAsync(user);
        
            userDtos.Add(new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Created = user.Created,
                LastActive = user.LastActive,
                Roles = roles,
                FavoriteArtistsCount = favoriteArtists.Count,
                FavoritePaintingsCount = favoritePaintings.Count
            });
        }

        _logger.LogInformation("Successfully retrieved {Count} users", userDtos.Count);

        return Ok(userDtos);
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
        var user = await _userManagerService.GetUserByIdAsync(id);
        if (user == null)
        {
            throw new NotFoundException($"User with ID '{id}' not found");
        }

        var roles = await _userManagerService.GetUserRolesAsync(user);
        
        var favoritePaintings = await _unitOfWork.UserFavoritesRepository.GetUserFavoritePaintingsAsync(user.Id);
        var favoriteArtists = await _unitOfWork.UserFavoritesRepository.GetUserFavoriteArtistsAsync(user.Id);

        var userDetail = new UserDetailDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Created = user.Created,
            LastActive = user.LastActive,
            EmailConfirmed = user.EmailConfirmed,
            Roles = roles,
            FavoriteArtistsCount = favoriteArtists.Count,
            FavoritePaintingsCount = favoritePaintings.Count
        };

        return Ok(userDetail);
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
        if (string.IsNullOrEmpty(userId))
        {
            throw new UnauthorizedException("User identity cannot be determined");
        }

        var user = await _userManagerService.GetUserByIdAsync(userId);
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        var roles = await _userManagerService.GetUserRolesAsync(user);
    
        // Get counts directly from the favorites repository
        var favoritePaintings = await _unitOfWork.UserFavoritesRepository.GetUserFavoritePaintingsAsync(userId);
        var favoriteArtists = await _unitOfWork.UserFavoritesRepository.GetUserFavoriteArtistsAsync(userId);

        var userProfile = new UserProfileDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Created = user.Created,
            LastActive = user.LastActive,
            Roles = roles,
            FavoriteArtistsCount = favoriteArtists.Count,
            FavoritePaintingsCount = favoritePaintings.Count
        };

        return Ok(userProfile);
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
    public async Task<IActionResult> UpdateUser(string id, UpdateUserRequest request)
    {
        await _userManagerService.UpdateUserAsync(id, request.FirstName, request.LastName, request.Email,
            request.UserName);
        return Ok(new { message = "User updated successfully" });
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
        if (!await _userManagerService.RoleExistsAsync(request.RoleName))
        {
            throw new NotFoundException($"Role '{request.RoleName}' does not exist");
        }

        var user = await _userManagerService.GetUserByIdAsync(id);
        if (user == null)
        {
            throw new NotFoundException($"User with ID '{id}' not found");
        }

        await _userManagerService.AddUserToRoleAsync(user, request.RoleName);

        var updatedRoles = await _userManagerService.GetUserRolesAsync(user);

        return Ok(new
        {
            message = $"Role '{request.RoleName}' assigned successfully",
            roles = updatedRoles
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
        var updatedRoles = await _userManagerService.RemoveUserFromRoleAsync(id, roleName);

        return Ok(new
        {
            message = $"Role '{roleName}' removed successfully",
            roles = updatedRoles
        });
    }
}