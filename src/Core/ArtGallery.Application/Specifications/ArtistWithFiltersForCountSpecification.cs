using ArtGallery.Domain.Entities;

namespace ArtGallery.Application.Specifications;

// EF Core SQL translation: ToLowerInvariant() maps to LOWER() in SQL Server; Contains(StringComparison) is not supported
#pragma warning disable CA1862

public class ArtistWithFiltersForCountSpecification : BaseSpecification<Artist>
{
    public ArtistWithFiltersForCountSpecification(ArtistSpecParams artistParams)
        : base(x =>
            (string.IsNullOrEmpty(artistParams.Search) || x.FirstName.ToLowerInvariant().Contains(artistParams.Search) ||
             x.LastName.ToLowerInvariant().Contains(artistParams.Search)) &&
            (string.IsNullOrEmpty(artistParams.Nationality) || x.Nationality == artistParams.Nationality)
        )
    {
    }
}
