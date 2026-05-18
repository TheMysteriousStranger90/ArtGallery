using MediatR;

namespace ArtGallery.Application.Features.Tags.Commands;

public class UpdateTagCommand : IRequest<UpdateTagCommandResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
