using MediatR;

namespace ArtGallery.Application.Features.Paintings.Commands;

public class RemovePaintingFromFavoriteCommand : IRequest<RemovePaintingFromFavoriteCommandResponse>
{
    public string? UserId { get; set; }
    public Guid PaintingId { get; set; }
}
