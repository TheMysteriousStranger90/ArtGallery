using ArtGallery.Application.DTOs;
using ArtGallery.Application.Responses;

namespace ArtGallery.Application.Features.Exhibitions.Commands;

public class CreateExhibitionCommandResponse : BaseResponse
{
    public CreateExhibitionCommandResponse() : base() { }
        
    public ExhibitionDto Exhibition { get; set; }
}