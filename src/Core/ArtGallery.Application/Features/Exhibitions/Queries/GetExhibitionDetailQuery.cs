using ArtGallery.Application.DTOs;
using MediatR;

namespace ArtGallery.Application.Features.Exhibitions.Queries;

public class GetExhibitionDetailQuery : IRequest<ExhibitionDetailDto>
{
    public Guid Id { get; set; }
}