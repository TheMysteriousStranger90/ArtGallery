using ArtGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Application.Specifications;

public class PaintingSpecification : BaseSpecification<Painting>
{
    public PaintingSpecification(PaintingSpecParams paintingParams)
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
        AddInclude(p => p.Artist);
        AddInclude(p => p.Genre);
        AddInclude(p => p.Museum);
        AddInclude(p => p.Museum.City);
        AddInclude(p => p.Museum.City.Country);

        switch (paintingParams.Sort?.ToLower())
        {
            case "title_desc":
                AddOrderByDescending(p => p.Title);
                break;
            case "year":
                AddOrderBy(p => p.CreationYear);
                break;
            case "year_desc":
                AddOrderByDescending(p => p.CreationYear);
                break;
            case "artist":
                AddOrderBy(p => p.Artist.LastName);
                break;
            case "artist_desc":
                AddOrderByDescending(p => p.Artist.LastName);
                break;
            case "genre":
                AddOrderBy(p => p.Genre.Name);
                break;
            case "painttype":
                AddOrderBy(p => p.PaintType);
                break;
            case "museum":
                AddOrderBy(p => p.Museum.Name);
                break;
            case "country":
                AddOrderBy(p => p.Museum.City.Country.Name);
                break;
            default:
                AddOrderBy(p => p.Title);
                break;
        }

        ApplyPaging(paintingParams.PageSize * (paintingParams.PageIndex - 1), paintingParams.PageSize);
    }

    public PaintingSpecification(Guid id) : base(x => x.Id == id)
    {
        // Basic includes
        AddInclude(p => p.Artist);
        AddInclude(p => p.Genre);
        AddInclude(p => p.Museum);
        AddInclude(p => p.PaintingImages);
        AddInclude(p => p.Tags);
        AddInclude(p => p.Exhibitions);

        // Add complex includes for nested navigation properties
        AddComplexIncludes(query => query
            // For Museum.City.Country
            .Include(p => p.Museum)
            .ThenInclude(m => m.City)
            .ThenInclude(c => c.Country)
            // For Tags.Tag
            .Include(p => p.Tags)
            .ThenInclude(t => t.Tag)
            // For Exhibitions.Exhibition
            .Include(p => p.Exhibitions)
            .ThenInclude(e => e.Exhibition)
        );
    }
}