using ArtGallery.Application.DTOs;
using ArtGallery.Application.Responses;

namespace ArtGallery.Application.Features.Paintings.Commands;

public class CreatePaintingCommandResponse : BaseResponse
{
    public CreatePaintingCommandResponse() : base() { }
        
    public PaintingDto Painting { get; set; }
}