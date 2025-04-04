using ArtGallery.Domain.Entities;

namespace ArtGallery.Application.Specifications;

public class ArtistWithFiltersForCountSpecification : BaseSpecification<Artist>
{
    public ArtistWithFiltersForCountSpecification(ArtistSpecParams artistParams)
        : base(x =>
            (string.IsNullOrEmpty(artistParams.Search) || x.FirstName.ToLower().Contains(artistParams.Search) ||
             x.LastName.ToLower().Contains(artistParams.Search)) &&
            (string.IsNullOrEmpty(artistParams.Nationality) || x.Nationality == artistParams.Nationality)
        )
    {
    }
}