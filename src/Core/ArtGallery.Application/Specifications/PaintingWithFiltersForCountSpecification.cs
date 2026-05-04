using ArtGallery.Domain.Entities;

namespace ArtGallery.Application.Specifications;

public class PaintingWithFiltersForCountSpecification : BaseSpecification<Painting>
{
    public PaintingWithFiltersForCountSpecification(PaintingSpecParams paintingParams)
        : base(x => 

            (string.IsNullOrEmpty(paintingParams.Search) || x.Title.ToLower().Contains(paintingParams.Search) || 
             x.Description.ToLower().Contains(paintingParams.Search)) &&

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