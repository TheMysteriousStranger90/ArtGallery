using MediatR;

namespace ArtGallery.Application.Features.Exhibitions.Commands;

public class RemovePaintingFromExhibitionCommand : IRequest<ManagePaintingCommandResponse>
{
    public Guid ExhibitionId { get; set; }
    public Guid PaintingId { get; set; }
}