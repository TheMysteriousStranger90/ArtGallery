using ArtGallery.Application.Responses;

namespace ArtGallery.Application.Features.Users.Commands;

public class RemoveRoleCommandResponse : BaseResponse
{
    public RemoveRoleCommandResponse() : base() { }

    public new string Message { get; set; } = string.Empty;
    public IList<string> Roles { get; set; } = new List<string>();
}
