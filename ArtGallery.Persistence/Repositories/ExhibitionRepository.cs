using ArtGallery.Application.Contracts.Persistence;
using ArtGallery.Domain.Entities;
using ArtGallery.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Persistence.Repositories;

public class ExhibitionRepository : GenericRepository<Exhibition>, IExhibitionRepository
{
    public ExhibitionRepository(ArtGalleryDbContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<Exhibition>> GetCurrentExhibitionsAsync()
    {
        var today = DateTime.UtcNow.Date;
        return await _context.Exhibitions
            .Include(e => e.Museum)
            .Where(e => e.StartDate <= today && e.EndDate >= today)
            .OrderBy(e => e.EndDate)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Exhibition>> GetUpcomingExhibitionsAsync()
    {
        var today = DateTime.UtcNow.Date;
        return await _context.Exhibitions
            .Include(e => e.Museum)
            .Where(e => e.StartDate > today)
            .OrderBy(e => e.StartDate)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Exhibition>> GetPastExhibitionsAsync()
    {
        var today = DateTime.UtcNow.Date;
        return await _context.Exhibitions
            .Include(e => e.Museum)
            .Where(e => e.EndDate < today)
            .OrderByDescending(e => e.EndDate)
            .ToListAsync();
    }

    public async Task<Exhibition> GetExhibitionWithPaintingsAsync(Guid exhibitionId)
    {
        return await _context.Exhibitions
            .Include(e => e.Museum)
            .Include(e => e.Paintings)
            .ThenInclude(pe => pe.Painting)
            .ThenInclude(p => p.Artist)
            .FirstOrDefaultAsync(e => e.Id == exhibitionId);
    }
}