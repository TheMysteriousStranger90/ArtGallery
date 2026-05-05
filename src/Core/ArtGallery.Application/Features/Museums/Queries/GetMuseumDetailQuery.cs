using ArtGallery.Application.DTOs;
using MediatR;

namespace ArtGallery.Application.Features.Museums.Queries;

public class GetMuseumDetailQuery : IRequest<MuseumDetailDto>
{
    public Guid Id { get; set; }
}
