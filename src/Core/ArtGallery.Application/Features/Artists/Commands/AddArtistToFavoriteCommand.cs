using MediatR;

namespace ArtGallery.Application.Features.Artists.Commands;

public class AddArtistToFavoriteCommand : IRequest<AddArtistToFavoriteCommandResponse>
{
    public string UserId { get; set; }
    public Guid ArtistId { get; set; }
}