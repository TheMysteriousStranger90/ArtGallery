using MediatR;

namespace ArtGallery.Application.Features.Exhibitions.Commands;

public class DeleteExhibitionCommand : IRequest<DeleteExhibitionCommandResponse>
{
    public Guid Id { get; set; }
}