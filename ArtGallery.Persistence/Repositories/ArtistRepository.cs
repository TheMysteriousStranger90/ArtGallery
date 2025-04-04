using ArtGallery.Application.Contracts.Persistence;
using ArtGallery.Domain.Entities;
using ArtGallery.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Persistence.Repositories;

public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
{
    public ArtistRepository(ArtGalleryDbContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<Artist>> GetArtistsByNationalityAsync(string nationality)
    {
        return await _context.Artists
            .Where(a => a.Nationality == nationality)
            .ToListAsync();
    }

    public async Task<Artist> GetArtistWithPaintingsAsync(Guid artistId)
    {
        return await _context.Artists
            .Include(a => a.Biography)
            .Include(a => a.ArtistImage.Where(ai => ai.IsMain))
            .Include(a => a.Paintings)
            .FirstOrDefaultAsync(a => a.Id == artistId);
    }

    public async Task<IReadOnlyList<string>> GetAllNationalitiesAsync()
    {
        return await _context.Artists
            .Where(a => !string.IsNullOrEmpty(a.Nationality))
            .Select(a => a.Nationality)
            .Distinct()
            .ToListAsync();
    }
}