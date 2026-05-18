using MediatR;

namespace ArtGallery.Application.Features.Tags.Commands;

public class DeleteTagCommand : IRequest<DeleteTagCommandResponse>
{
    public Guid Id { get; set; }
}
