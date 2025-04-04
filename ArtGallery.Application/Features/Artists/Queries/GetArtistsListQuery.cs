using ArtGallery.Application.DTOs;
using ArtGallery.Application.Helpers;
using MediatR;

namespace ArtGallery.Application.Features.Artists.Queries;

public class GetArtistsListQuery : IRequest<Pagination<ArtistDto>>
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string Search { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public string Sort { get; set; } = "lastName";
}