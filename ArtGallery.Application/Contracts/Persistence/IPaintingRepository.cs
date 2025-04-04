using ArtGallery.Domain.Entities;
using ArtGallery.Domain.Entities.Enums;

namespace ArtGallery.Application.Contracts.Persistence;

public interface IPaintingRepository : IGenericRepository<Painting>
{
    Task<Painting> GetPaintingWithDetailsAsync(Guid id);
    Task<IReadOnlyList<Painting>> GetPaintingsByArtistAsync(Guid artistId);
    Task<IReadOnlyList<Painting>> GetPaintingsByMuseumAsync(Guid museumId);
    Task<IReadOnlyList<Painting>> GetPaintingsByGenreAsync(Guid genreId);
    Task<IReadOnlyList<Painting>> GetPaintingsByPaintTypeAsync(PaintType paintType);
    Task<IReadOnlyList<Painting>> GetPaintingsByYearRangeAsync(int fromYear, int toYear);
}