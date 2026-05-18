using ArtGallery.Application.DTOs;
using ArtGallery.Application.Responses;

namespace ArtGallery.Application.Features.Tags.Commands;

public class CreateTagCommandResponse : BaseResponse
{
    public CreateTagCommandResponse() : base() { }
    public TagDto? Tag { get; set; }
}
