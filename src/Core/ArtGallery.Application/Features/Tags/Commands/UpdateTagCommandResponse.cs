using ArtGallery.Application.DTOs;
using ArtGallery.Application.Responses;

namespace ArtGallery.Application.Features.Tags.Commands;

public class UpdateTagCommandResponse : BaseResponse
{
    public UpdateTagCommandResponse() : base() { }
    public TagDto? Tag { get; set; }
}
