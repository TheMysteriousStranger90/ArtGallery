using ArtGallery.Application.DTOs;
using MediatR;

namespace ArtGallery.Application.Features.Artists.Queries;

public class GetArtistDetailQuery : IRequest<ArtistDetailDto>
{
    public Guid Id { get; set; }
}