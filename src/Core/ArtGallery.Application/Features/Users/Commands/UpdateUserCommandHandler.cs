using ArtGallery.Application.Contracts.Identity;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ArtGallery.Application.Features.Users.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse>
    {
        private readonly IUserManagerService _userManagerService;
        private readonly ILogger<UpdateUserCommandHandler> _logger;

        public UpdateUserCommandHandler(
            IUserManagerService userManagerService,
            ILogger<UpdateUserCommandHandler> logger)
        {
            _userManagerService = userManagerService;
            _logger = logger;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateUserCommandResponse();

            try
            {
                _logger.LogInformation("Updating user with ID: {UserId}", request.Id);

                await _userManagerService.UpdateUserAsync(
                    request.Id,
                    request.FirstName,
                    request.LastName,
                    request.Email,
                    request.UserName);

                response.Success = true;
                response.Message = "User updated successfully";

                _logger.LogInformation("User {UserId} updated successfully", request.Id);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                _logger.LogError(ex, "Error updating user {UserId}", request.Id);
            }

            return response;
        }
    }
}