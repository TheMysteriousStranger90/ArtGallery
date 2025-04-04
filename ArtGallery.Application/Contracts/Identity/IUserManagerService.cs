using ArtGallery.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ArtGallery.Application.Contracts.Identity;

public interface IUserManagerService
{
    UserManager<ApplicationUser> UserManager { get; }
    SignInManager<ApplicationUser> SignInManager { get; }
    RoleManager<AppRole> RoleManager { get; }
    
    Task<bool> CreateUserAsync(ApplicationUser user, string password);
    Task<bool> UserExistsAsync(string username);
    Task<ApplicationUser> GetUserByUsernameAsync(string username);
    Task<ApplicationUser> GetUserByIdAsync(string id);
    Task<IList<string>> GetUserRolesAsync(ApplicationUser user);
    Task<bool> CheckUserPasswordAsync(ApplicationUser user, string password);
    Task<bool> AddUserToRoleAsync(ApplicationUser user, string roleName);
    
    Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
    
    Task<bool> RoleExistsAsync(string roleName);
    Task UpdateUserAsync(string userId, string firstName, string lastName, string email, string userName);
    Task<IList<string>> RemoveUserFromRoleAsync(string userId, string roleName);
}