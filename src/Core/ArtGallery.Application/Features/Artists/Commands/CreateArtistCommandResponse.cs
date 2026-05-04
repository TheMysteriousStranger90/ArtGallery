using ArtGallery.Application.DTOs;
using ArtGallery.Application.Responses;

namespace ArtGallery.Application.Features.Artists.Commands;

public class CreateArtistCommandResponse : BaseResponse
{
    public CreateArtistCommandResponse() : base() { }
        
    public CreateArtistDto Artist { get; set; }
}