using MediatR;

namespace ArtGallery.Application.Features.Tags.Commands;

public class CreateTagCommand : IRequest<CreateTagCommandResponse>
{
    public string Name { get; set; } = string.Empty;
}
