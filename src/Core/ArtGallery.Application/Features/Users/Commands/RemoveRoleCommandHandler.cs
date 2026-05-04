using ArtGallery.Application.Contracts.Identity;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ArtGallery.Application.Features.Users.Commands
{
    public class RemoveRoleCommandHandler : IRequestHandler<RemoveRoleCommand, RemoveRoleCommandResponse>
    {
        private readonly IUserManagerService _userManagerService;
        private readonly ILogger<RemoveRoleCommandHandler> _logger;

        public RemoveRoleCommandHandler(
            IUserManagerService userManagerService,
            ILogger<RemoveRoleCommandHandler> logger)
        {
            _userManagerService = userManagerService;
            _logger = logger;
        }

        public async Task<RemoveRoleCommandResponse> Handle(RemoveRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new RemoveRoleCommandResponse();

            try
            {
                _logger.LogInformation("Removing role {RoleName} from user {UserId}", request.RoleName, request.UserId);

                var updatedRoles = await _userManagerService.RemoveUserFromRoleAsync(request.UserId, request.RoleName);

                response.Success = true;
                response.Message = $"Role '{request.RoleName}' removed successfully";
                response.Roles = updatedRoles;

                _logger.LogInformation("Role {RoleName} removed successfully from user {UserId}", request.RoleName, request.UserId);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                _logger.LogError(ex, "Error removing role {RoleName} from user {UserId}", request.RoleName, request.UserId);
            }

            return response;
        }
    }
}