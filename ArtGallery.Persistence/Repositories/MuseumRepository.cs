using ArtGallery.Application.Contracts.Persistence;
using ArtGallery.Domain.Entities;
using ArtGallery.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Persistence.Repositories;

public class MuseumRepository : GenericRepository<Museum>, IMuseumRepository
{
    public MuseumRepository(ArtGalleryDbContext context) : base(context)
    {
    }

    public async Task<Museum> GetMuseumWithPaintingsAsync(Guid museumId)
    {
        return await _context.Museums
            .Include(m => m.City)
            .ThenInclude(c => c.Country)
            .Include(m => m.Paintings)
            .ThenInclude(p => p.Artist)
            .FirstOrDefaultAsync(m => m.Id == museumId);
    }

    public async Task<IReadOnlyList<Museum>> GetMuseumsByCountryAsync(Guid countryId)
    {
        return await _context.Museums
            .Include(m => m.City)
            .ThenInclude(c => c.Country)
            .Where(m => m.City.CountryId == countryId)
            .OrderBy(m => m.Name)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Museum>> GetMuseumsByCityAsync(Guid cityId)
    {
        return await _context.Museums
            .Include(m => m.City)
            .Where(m => m.CityId == cityId)
            .OrderBy(m => m.Name)
            .ToListAsync();
    }
}