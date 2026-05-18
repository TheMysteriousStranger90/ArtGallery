using ArtGallery.Domain.Entities;

namespace ArtGallery.Application.Specifications;

// EF Core translates .ToLower() to SQL LOWER(); culture-specific overload is not supported by the provider
#pragma warning disable CA1304, CA1311, CA1862

public class ArtistWithFiltersForCountSpecification : BaseSpecification<Artist>
{
    public ArtistWithFiltersForCountSpecification(ArtistSpecParams artistParams)
        : base(x =>
            (string.IsNullOrEmpty(artistParams.Search) ||
             x.FirstName.ToLower().Contains(artistParams.Search) ||
             x.LastName.ToLower().Contains(artistParams.Search) ||
             (x.FirstName + " " + x.LastName).ToLower().Contains(artistParams.Search)) &&
            (string.IsNullOrEmpty(artistParams.Nationality) || x.Nationality == artistParams.Nationality)
        )
    {
    }
}
