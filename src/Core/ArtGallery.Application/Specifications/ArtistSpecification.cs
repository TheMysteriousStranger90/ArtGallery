using ArtGallery.Domain.Entities;

namespace ArtGallery.Application.Specifications;

// EF Core translates .ToLower() to SQL LOWER(); culture-specific overload is not supported by the provider
#pragma warning disable CA1304, CA1311, CA1862, CS8603

public class ArtistSpecification : BaseSpecification<Artist>
{
    public ArtistSpecification(ArtistSpecParams artistParams)
        : base(x =>
            (string.IsNullOrEmpty(artistParams.Search) ||
             x.FirstName.ToLower().Contains(artistParams.Search) ||
             x.LastName.ToLower().Contains(artistParams.Search) ||
             (x.FirstName + " " + x.LastName).ToLower().Contains(artistParams.Search)) &&
            (string.IsNullOrEmpty(artistParams.Nationality) || x.Nationality == artistParams.Nationality)
        )
    {
        AddInclude(a => a.Biography);
        AddInclude(a => a.ArtistImage.Where(i => i.IsMain));

        switch (artistParams.Sort?.ToLowerInvariant())
        {
            case "firstname":
                AddOrderBy(a => a.FirstName);
                break;
            case "birthdate":
                AddOrderBy(a => a.BirthDate);
                break;
            case "lastname_desc":
                AddOrderByDescending(a => a.LastName);
                break;
            case "firstname_desc":
                AddOrderByDescending(a => a.FirstName);
                break;
            default:
                AddOrderBy(a => a.LastName);
                break;
        }

        ApplyPaging(artistParams.PageSize * (artistParams.PageIndex - 1), artistParams.PageSize);
    }

    public ArtistSpecification(Guid id) : base(x => x.Id == id)
    {
        AddInclude(a => a.Biography);
        AddInclude(a => a.ArtistImage);
        AddInclude(a => a.Paintings);
    }
}

