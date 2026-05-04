using MediatR;

namespace ArtGallery.Application.Features.Exhibitions.Commands;

public class CreateExhibitionCommand : IRequest<CreateExhibitionCommandResponse>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string ExternalVenueAddress { get; set; }
    public Guid? MuseumId { get; set; }
    public List<Guid> PaintingIds { get; set; } = new List<Guid>();
}