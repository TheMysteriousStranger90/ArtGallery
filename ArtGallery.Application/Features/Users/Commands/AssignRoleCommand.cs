using MediatR;

namespace ArtGallery.Application.Features.Users.Commands
{
    public class AssignRoleCommand : IRequest<AssignRoleCommandResponse>
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}