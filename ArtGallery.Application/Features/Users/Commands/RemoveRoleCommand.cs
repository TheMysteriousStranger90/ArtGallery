using MediatR;

namespace ArtGallery.Application.Features.Users.Commands
{
    public class RemoveRoleCommand : IRequest<RemoveRoleCommandResponse>
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}