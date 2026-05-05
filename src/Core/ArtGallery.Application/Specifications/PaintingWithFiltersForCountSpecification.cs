using ArtGallery.Domain.Entities;

namespace ArtGallery.Application.Specifications;

// EF Core SQL translation: ToLowerInvariant() maps to LOWER() in SQL Server; Contains(StringComparison) is not supported
#pragma warning disable CA1862

public class PaintingWithFiltersForCountSpecification : BaseSpecification<Painting>
{
    public PaintingWithFiltersForCountSpecification(PaintingSpecParams paintingParams)
        : base(x =>

            (string.IsNullOrEmpty(paintingParams.Search) || x.Title.ToLowerInvariant().Contains(paintingParams.Search) ||
             x.Description.ToLowerInvariant().Contains(paintingParams.Search)) &&

            (!paintingParams.ArtistId.HasValue || x.ArtistId == paintingParams.ArtistId) &&

            (!paintingParams.GenreId.HasValue || x.GenreId == paintingParams.GenreId) &&

            (!paintingParams.MuseumId.HasValue || x.MuseumId == paintingParams.MuseumId) &&

            (!paintingParams.PaintType.HasValue || x.PaintType == paintingParams.PaintType) &&

            (!paintingParams.FromYear.HasValue || x.CreationYear >= paintingParams.FromYear) &&
            (!paintingParams.ToYear.HasValue || x.CreationYear <= paintingParams.ToYear)
        )
    {
    }
}
