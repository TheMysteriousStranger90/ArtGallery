using ArtGallery.Application.DTOs;
using MediatR;

namespace ArtGallery.Application.Features.Exhibitions.Queries;

public class GetExhibitionsListQuery : IRequest<List<ExhibitionDto>>
{
    public Guid? MuseumId { get; set; }
}