using ArtGallery.Application.Contracts.Identity;
using ArtGallery.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ArtGallery.Application.Features.Users.Commands
{
    public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommand, AssignRoleCommandResponse>
    {
        private readonly IUserManagerService _userManagerService;
        private readonly ILogger<AssignRoleCommandHandler> _logger;

        public AssignRoleCommandHandler(
            IUserManagerService userManagerService,
            ILogger<AssignRoleCommandHandler> logger)
        {
            _userManagerService = userManagerService;
            _logger = logger;
        }

        public async Task<AssignRoleCommandResponse> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new AssignRoleCommandResponse();

            try
            {
                _logger.LogInformation("Assigning role {RoleName} to user {UserId}", request.RoleName, request.UserId);

                if (!await _userManagerService.RoleExistsAsync(request.RoleName))
                {
                    throw new NotFoundException($"Role '{request.RoleName}' does not exist");
                }

                var user = await _userManagerService.GetUserByIdAsync(request.UserId);
                if (user == null)
                {
                    throw new NotFoundException($"User with ID '{request.UserId}' not found");
                }

                await _userManagerService.AddUserToRoleAsync(user, request.RoleName);
                var updatedRoles = await _userManagerService.GetUserRolesAsync(user);

                response.Success = true;
                response.Message = $"Role '{request.RoleName}' assigned successfully";
                response.Roles = updatedRoles;

                _logger.LogInformation("Role {RoleName} assigned successfully to user {UserId}", request.RoleName, request.UserId);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                _logger.LogError(ex, "Error assigning role {RoleName} to user {UserId}", request.RoleName, request.UserId);
            }

            return response;
        }
    }
}