using MediatR;

namespace ArtGallery.Application.Features.Artists.Commands;

public class DeleteArtistCommand : IRequest<DeleteArtistCommandResponse>
{
    public Guid Id { get; set; }
}