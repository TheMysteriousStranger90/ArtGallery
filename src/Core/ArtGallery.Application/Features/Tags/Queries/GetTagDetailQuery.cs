using MediatR;

namespace ArtGallery.Application.Features.Tags.Queries;

public class GetTagDetailQuery : IRequest<TagDetailResponse>
{
    public Guid Id { get; set; }
}
