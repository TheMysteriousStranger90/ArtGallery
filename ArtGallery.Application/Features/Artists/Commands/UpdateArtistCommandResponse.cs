using ArtGallery.Application.DTOs;
using ArtGallery.Application.Responses;

namespace ArtGallery.Application.Features.Artists.Commands;

public class UpdateArtistCommandResponse : BaseResponse
{
    public UpdateArtistCommandResponse() : base() { }
        
    public ArtistDto Artist { get; set; }
}