using MediatR;

namespace ArtGallery.Application.Features.Paintings.Commands;

public class AddPaintingToFavoriteCommand : IRequest<AddPaintingToFavoriteCommandResponse>
{
    public string UserId { get; set; }
    public Guid PaintingId { get; set; }
}