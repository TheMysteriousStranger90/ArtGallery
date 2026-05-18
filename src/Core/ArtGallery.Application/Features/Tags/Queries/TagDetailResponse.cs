using ArtGallery.Application.DTOs;
using ArtGallery.Application.Responses;

namespace ArtGallery.Application.Features.Tags.Queries;

public class TagDetailResponse : BaseResponse
{
    public TagDto? Tag { get; set; }
}
