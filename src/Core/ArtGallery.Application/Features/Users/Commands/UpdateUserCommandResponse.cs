using ArtGallery.Application.Responses;

namespace ArtGallery.Application.Features.Users.Commands;

public class UpdateUserCommandResponse : BaseResponse
{
    public UpdateUserCommandResponse() : base() { }

    public new string Message { get; set; } = string.Empty;
}
