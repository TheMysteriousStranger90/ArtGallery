using ArtGallery.Application.DTOs;
using ArtGallery.Application.Responses;

namespace ArtGallery.Application.Features.Paintings.Commands;

public class UpdatePaintingCommandResponse : BaseResponse
{
    public UpdatePaintingCommandResponse() : base() { }
        
    public PaintingDto Painting { get; set; }
}