using ArtGallery.Application.Contracts.Persistence;
using ArtGallery.Domain.Entities;
using ArtGallery.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Persistence.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly ArtGalleryDbContext _context;

    public ImageRepository(ArtGalleryDbContext context)
    {
        _context = context;
    }

    public async Task<ArtistImage> GetArtistPhotoByIdAsync(Guid artistImageId)
    {
        return await _context.ArtistImages
            .Include(ai => ai.Artist)
            .FirstOrDefaultAsync(ai => ai.Id == artistImageId);
    }

    public async Task<PaintingImage> GetPaintingPhotoByIdAsync(Guid paintingImageId)
    {
        return await _context.PaintingImages
            .Include(pi => pi.Painting)
            .FirstOrDefaultAsync(pi => pi.Id == paintingImageId);
    }

    public void RemoveArtistImage(ArtistImage image)
    {
        _context.ArtistImages.Remove(image);
    }

    public void RemovePaintingImage(PaintingImage image)
    {
        _context.PaintingImages.Remove(image);
    }
}