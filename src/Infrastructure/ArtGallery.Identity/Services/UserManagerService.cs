using ArtGallery.Application.Contracts.Identity;
using ArtGallery.Application.Exceptions;
using ArtGallery.Domain.Entities;
using ArtGallery.Identity.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ArtGallery.Identity.Services;

public class UserManagerService : IUserManagerService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly IServiceProvider _serviceProvider;

    public UserManagerService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<AppRole> roleManager,
        IServiceProvider serviceProvider)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _serviceProvider = serviceProvider;
    }

    public UserManager<ApplicationUser> UserManager => _userManager;
    public SignInManager<ApplicationUser> SignInManager => _signInManager;
    public RoleManager<AppRole> RoleManager => _roleManager;

    public async Task<bool> CreateUserAsync(ApplicationUser user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);
        return result.Succeeded;
    }

    public async Task<bool> UserExistsAsync(string username)
    {
        return await _userManager.FindByNameAsync(username) != null;
    }

    public async Task<ApplicationUser> GetUserByUsernameAsync(string username)
    {
        return await _userManager.FindByNameAsync(username);
    }

    public async Task<ApplicationUser> GetUserByIdAsync(string id)
    {
        return await UserManager.Users
            .Include(u => u.FavoritePaintings)
            .Include(u => u.FavoriteArtists)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IList<string>> GetUserRolesAsync(ApplicationUser user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        // First try direct database access through the DbContext
        // This bypasses any caching or other issues in the UserManager
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ArtGalleryIdentityDbContext>();

            // Direct SQL approach through Entity Framework
            var userRoleIds = await dbContext.UserRoles
                .Where(ur => ur.UserId == user.Id)
                .Select(ur => ur.RoleId)
                .ToListAsync();

            if (userRoleIds.Any())
            {
                var roleNames = await dbContext.Roles
                    .Where(r => userRoleIds.Contains(r.Id))
                    .Select(r => r.Name)
                    .ToListAsync();

                if (roleNames.Any())
                {
                    return roleNames;
                }
            }
        }

        // Fall back to standard approach
        return await _userManager.GetRolesAsync(user);
    }

    public async Task<bool> CheckUserPasswordAsync(ApplicationUser user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<bool> AddUserToRoleAsync(ApplicationUser user, string roleName)
    {
        var result = await _userManager.AddToRoleAsync(user, roleName);
        return result.Succeeded;
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
    {
        return await UserManager.Users
            .Include(u => u.FavoritePaintings)
            .Include(u => u.FavoriteArtists)
            .ToListAsync();
    }

    // In IdentityService
    public async Task<bool> RoleExistsAsync(string roleName)
    {
        return await _roleManager.RoleExistsAsync(roleName);
    }

    public async Task UpdateUserAsync(string userId, string firstName, string lastName, string email, string userName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new NotFoundException($"User with ID '{userId}' not found");
        }

        user.FirstName = firstName;
        user.LastName = lastName;
        user.Email = email;
        user.UserName = userName;

        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            throw new BadRequestException(
                "Failed to update user",
                result.Errors.Select(e => e.Description).ToList()
            );
        }
    }

    public async Task<IList<string>> RemoveUserFromRoleAsync(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new NotFoundException($"User with ID '{userId}' not found");
        }

        // Check if user has the role
        if (!await _userManager.IsInRoleAsync(user, roleName))
        {
            throw new BadRequestException($"User does not have role '{roleName}'");
        }

        var result = await _userManager.RemoveFromRoleAsync(user, roleName);
        if (!result.Succeeded)
        {
            throw new BadRequestException(
                $"Failed to remove role '{roleName}'",
                result.Errors.Select(e => e.Description).ToList()
            );
        }

        return await GetUserRolesAsync(user);
    }
    
    public async Task UpdateLastActiveAsync(string userId)
    {
        var user = await UserManager.FindByIdAsync(userId);
        if (user != null)
        {
            user.LastActive = DateTime.UtcNow;
            await UserManager.UpdateAsync(user);
        }
    }
}