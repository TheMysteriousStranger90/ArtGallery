using ArtGallery.Application.Contracts.Persistence;
using ArtGallery.Domain.Entities;
using ArtGallery.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Persistence.Repositories;

public class PaintingRepository : GenericRepository<Painting>, IPaintingRepository
{
    public PaintingRepository(ArtGalleryDbContext context) : base(context)
    {
    }

    public async Task<Painting?> GetPaintingWithDetailsAsync(Guid id)
    {
        return await _context.Paintings
            .Include(p => p.Artist)
            .Include(p => p.Genre)
            .Include(p => p.Museum)
            .ThenInclude(m => m.City)
            .ThenInclude(c => c.Country)
            .Include(p => p.PaintingImages)
            .Include(p => p.Tags)
            .ThenInclude(pt => pt.Tag)
            .Include(p => p.Exhibitions)
            .ThenInclude(pe => pe.Exhibition)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}
