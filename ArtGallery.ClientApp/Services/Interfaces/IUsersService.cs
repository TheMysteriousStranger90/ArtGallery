using System.Collections.Generic;
using System.Threading.Tasks;
using ArtGallery.ClientApp.Constants;

namespace ArtGallery.ClientApp.Services.Interfaces
{
    public interface IUsersService
    {
        Task<ICollection<UserDto>> GetAllUsersAsync(string apiVersion = Const.DefaultApiVersion);
        Task<UserDetailDto> GetUserByIdAsync(string id, string apiVersion = Const.DefaultApiVersion);
        Task<UserProfileDto> GetCurrentUserAsync(string apiVersion = Const.DefaultApiVersion);
        Task<bool> UpdateUserAsync(string id, UpdateUserRequest request, string apiVersion = Const.DefaultApiVersion);
        Task<bool> AssignRoleToUserAsync(string id, AssignRoleRequest request, string apiVersion = Const.DefaultApiVersion);
        Task<bool> RemoveRoleFromUserAsync(string id, string roleName, string apiVersion = Const.DefaultApiVersion);
    }
}