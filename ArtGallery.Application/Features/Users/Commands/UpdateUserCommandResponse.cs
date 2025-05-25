using ArtGallery.Application.Responses;

namespace ArtGallery.Application.Features.Users.Commands;

public class UpdateUserCommandResponse : BaseResponse
{
    public UpdateUserCommandResponse() : base() { }
        
    public string Message { get; set; }
}