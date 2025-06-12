using ArtGallery.ClientApp.Services.Interfaces;
using ArtGallery.ClientApp.Constants;

namespace ArtGallery.ClientApp.Services
{
    public class UsersService : IUsersService
    {
        private readonly IClient _client;
        private readonly ILogger<UsersService> _logger;

        public UsersService(IClient client, ILogger<UsersService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ICollection<UserDto>> GetAllUsersAsync(string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Fetching all users");
                return await _client.UsersAllAsync(apiVersion);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, "API error fetching all users. Status: {StatusCode}, Response: {Response}",
                    ex.StatusCode, ex.Response);
                return new List<UserDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error fetching all users.");
                return new List<UserDto>();
            }
        }

        public async Task<UserDetailDto> GetUserByIdAsync(string id, string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Fetching user details for ID: {UserId}", id);
                return await _client.UsersGETAsync(id, apiVersion);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex,
                    "API error fetching user details for ID {UserId}. Status: {StatusCode}, Response: {Response}",
                    id, ex.StatusCode, ex.Response);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error fetching user details for ID {UserId}.", id);
                return null;
            }
        }

        public async Task<UserProfileDto> GetCurrentUserAsync(string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Fetching current user profile");
                return await _client.MeAsync(apiVersion);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex,
                    "API error fetching current user profile. Status: {StatusCode}, Response: {Response}",
                    ex.StatusCode, ex.Response);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error fetching current user profile.");
                return null;
            }
        }

        public async Task<bool> UpdateUserAsync(string id, UpdateUserRequest request,
            string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Updating user with ID: {UserId}", id);
                await _client.UsersPUTAsync(id, apiVersion, request);
                return true;
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex,
                    "API error updating user ID {UserId}. Status: {StatusCode}, Response: {Response}",
                    id, ex.StatusCode, ex.Response);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error updating user ID {UserId}.", id);
                return false;
            }
        }

        public async Task<bool> AssignRoleToUserAsync(string id, AssignRoleRequest request,
            string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Assigning role {RoleName} to user ID: {UserId}", request.RoleName, id);
                await _client.RolesPOSTAsync(id, apiVersion, request);
                return true;
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex,
                    "API error assigning role {RoleName} to user ID {UserId}. Status: {StatusCode}, Response: {Response}",
                    request.RoleName, id, ex.StatusCode, ex.Response);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error assigning role {RoleName} to user ID {UserId}.", request.RoleName,
                    id);
                return false;
            }
        }

        public async Task<bool> RemoveRoleFromUserAsync(string id, string roleName,
            string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Removing role {RoleName} from user ID: {UserId}", roleName, id);
                await _client.RolesDELETEAsync(id, roleName, apiVersion);
                return true;
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex,
                    "API error removing role {RoleName} from user ID {UserId}. Status: {StatusCode}, Response: {Response}",
                    roleName, id, ex.StatusCode, ex.Response);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error removing role {RoleName} from user ID {UserId}.", roleName, id);
                return false;
            }
        }
    }
}