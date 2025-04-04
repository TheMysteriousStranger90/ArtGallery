using ArtGallery.Application.DTOs;
using ArtGallery.Application.Responses;

namespace ArtGallery.Application.Features.Artists.Queries;

public class UserFavoriteArtistsResponse : BaseResponse
{
    public UserFavoriteArtistsResponse() : base()
    {
    }

    public List<ArtistDto> FavoriteArtists { get; set; } = new List<ArtistDto>();
    public int Count { get; set; }
}