using MediatR;

namespace ArtGallery.Application.Features.Artists.Commands;

public class RemoveArtistFromFavoriteCommand : IRequest<RemoveArtistFromFavoriteCommandResponse>
{
    public string? UserId { get; set; }
    public Guid ArtistId { get; set; }
}
