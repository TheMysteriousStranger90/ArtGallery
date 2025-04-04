using ArtGallery.Application.Responses;

namespace ArtGallery.Application.Features.Artists.Commands;

public class AddArtistToFavoriteCommandResponse : BaseResponse
{
    public AddArtistToFavoriteCommandResponse() : base() { }
        
    public bool IsFavorite { get; set; }
}