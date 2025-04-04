using ArtGallery.Application.Contracts.Persistence;
using ArtGallery.Domain.Entities;
using ArtGallery.Domain.Entities.Enums;
using ArtGallery.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Persistence.Repositories;

public class PaintingRepository : GenericRepository<Painting>, IPaintingRepository
{
    public PaintingRepository(ArtGalleryDbContext context) : base(context)
    {
    }

    public async Task<Painting> GetPaintingWithDetailsAsync(Guid id)
    {
        return await _context.Paintings
            .Include(p => p.Artist)
            .Include(p => p.Genre)
            .Include(p => p.Museum)
                .ThenInclude(m => m.City)
                    .ThenInclude(c => c.Country)
            .Include(p => p.Tags)
                .ThenInclude(pt => pt.Tag)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IReadOnlyList<Painting>> GetPaintingsByArtistAsync(Guid artistId)
    {
        return await _context.Paintings
            .Include(p => p.Artist)
            .Include(p => p.Genre)
            .Where(p => p.ArtistId == artistId)
            .OrderBy(p => p.CreationYear)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Painting>> GetPaintingsByMuseumAsync(Guid museumId)
    {
        return await _context.Paintings
            .Include(p => p.Artist)
            .Include(p => p.Museum)
            .Where(p => p.MuseumId == museumId)
            .OrderBy(p => p.Artist.LastName)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Painting>> GetPaintingsByGenreAsync(Guid genreId)
    {
        return await _context.Paintings
            .Include(p => p.Artist)
            .Include(p => p.Genre)
            .Where(p => p.GenreId == genreId)
            .OrderBy(p => p.Title)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Painting>> GetPaintingsByPaintTypeAsync(PaintType paintType)
    {
        return await _context.Paintings
            .Include(p => p.Artist)
            .Where(p => p.PaintType == paintType)
            .OrderBy(p => p.Title)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Painting>> GetPaintingsByYearRangeAsync(int fromYear, int toYear)
    {
        return await _context.Paintings
            .Include(p => p.Artist)
            .Where(p => p.CreationYear >= fromYear && p.CreationYear <= toYear)
            .OrderBy(p => p.CreationYear)
            .ToListAsync();
    }
}