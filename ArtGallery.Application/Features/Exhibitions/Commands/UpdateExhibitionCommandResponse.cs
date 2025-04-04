using ArtGallery.Application.DTOs;
using ArtGallery.Application.Responses;

namespace ArtGallery.Application.Features.Exhibitions.Commands;

public class UpdateExhibitionCommandResponse : BaseResponse
{
    public UpdateExhibitionCommandResponse() : base() { }
        
    public ExhibitionDto Exhibition { get; set; }
}