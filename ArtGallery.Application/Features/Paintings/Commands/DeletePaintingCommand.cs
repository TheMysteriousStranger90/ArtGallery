using MediatR;

namespace ArtGallery.Application.Features.Paintings.Commands;

public class DeletePaintingCommand : IRequest<DeletePaintingCommandResponse>
{
    public Guid Id { get; set; }
}