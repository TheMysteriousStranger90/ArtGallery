using ArtGallery.Application.Responses;

namespace ArtGallery.Application.Features.Paintings.Commands;

public class AddPaintingToFavoriteCommandResponse : BaseResponse
{
    public AddPaintingToFavoriteCommandResponse() : base() { }
        
    public bool IsFavorite { get; set; }
}