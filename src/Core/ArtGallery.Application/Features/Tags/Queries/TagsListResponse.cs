using ArtGallery.Application.DTOs;
using ArtGallery.Application.Responses;

namespace ArtGallery.Application.Features.Tags.Queries;

public class TagsListResponse : BaseResponse
{
    public List<TagDto> Tags { get; set; } = new();
    public int Count { get; set; }
}
