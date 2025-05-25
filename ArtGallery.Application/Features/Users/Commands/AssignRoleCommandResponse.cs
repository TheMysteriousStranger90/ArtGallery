using ArtGallery.Application.Responses;

namespace ArtGallery.Application.Features.Users.Commands
{
    public class AssignRoleCommandResponse : BaseResponse
    {
        public AssignRoleCommandResponse() : base() { }
        
        public string Message { get; set; }
        public IList<string> Roles { get; set; } = new List<string>();
    }
}