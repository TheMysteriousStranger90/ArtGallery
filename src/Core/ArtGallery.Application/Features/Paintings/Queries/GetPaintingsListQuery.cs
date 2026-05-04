using ArtGallery.Application.DTOs;
using ArtGallery.Application.Helpers;
using ArtGallery.Domain.Entities.Enums;
using MediatR;

namespace ArtGallery.Application.Features.Paintings.Queries;

public class GetPaintingsListQuery : IRequest<Pagination<PaintingDto>>
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 9;
    public string Search { get; set; } = string.Empty;
    public Guid? ArtistId { get; set; }
    public Guid? GenreId { get; set; }
    public Guid? MuseumId { get; set; }
    public PaintType? PaintType { get; set; }
    public int? FromYear { get; set; }
    public int? ToYear { get; set; }
    public string Sort { get; set; } = "title";
}