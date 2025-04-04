using ArtGallery.Application.DTOs;
using ArtGallery.Application.Responses;

namespace ArtGallery.Application.Features.Paintings.Queries;

public class UserFavoritePaintingsResponse : BaseResponse
{
    public UserFavoritePaintingsResponse() : base()
    {
    }

    public List<PaintingDto> FavoritePaintings { get; set; } = new List<PaintingDto>();
    public int Count { get; set; }
}