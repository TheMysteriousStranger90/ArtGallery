using ArtGallery.Application.Contracts.Persistence;
using ArtGallery.Domain.Entities;
using ArtGallery.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Persistence.Repositories;

public class UserFavoritesRepository : IUserFavoritesRepository
{
    private readonly ArtGalleryDbContext _context;

    public UserFavoritesRepository(ArtGalleryDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<UserFavoritePainting>> GetUserFavoritePaintingsAsync(string userId)
    {
        return await _context.Set<UserFavoritePainting>()
            .Include(ufp => ufp.Painting)
                .ThenInclude(p => p.Artist)
            .Where(ufp => ufp.UserId == userId)
            .ToListAsync();
    }

    public async Task<bool> AddFavoritePaintingAsync(string userId, Guid paintingId)
    {
        var favoriteExists = await IsPaintingFavoriteAsync(userId, paintingId);

        if (favoriteExists)
            return false;

        var favorite = new UserFavoritePainting
        {
            UserId = userId,
            PaintingId = paintingId
        };

        await _context.Set<UserFavoritePainting>().AddAsync(favorite);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveFavoritePaintingAsync(string userId, Guid paintingId)
    {
        var favorite = await _context.Set<UserFavoritePainting>()
            .FirstOrDefaultAsync(ufp => ufp.UserId == userId && ufp.PaintingId == paintingId);

        if (favorite == null)
            return false;

        _context.Set<UserFavoritePainting>().Remove(favorite);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> IsPaintingFavoriteAsync(string userId, Guid paintingId)
    {
        return await _context.Set<UserFavoritePainting>()
            .AnyAsync(ufp => ufp.UserId == userId && ufp.PaintingId == paintingId);
    }

    public async Task<IReadOnlyList<UserFavoriteArtist>> GetUserFavoriteArtistsAsync(string userId)
    {
        return await _context.Set<UserFavoriteArtist>()
            .Include(ufa => ufa.Artist)
                .ThenInclude(a => a.ArtistImage.Where(ai => ai.IsMain))
            .Where(ufa => ufa.UserId == userId)
            .ToListAsync();
    }

    public async Task<bool> AddFavoriteArtistAsync(string userId, Guid artistId)
    {
        var favoriteExists = await IsArtistFavoriteAsync(userId, artistId);

        if (favoriteExists)
            return false;

        var favorite = new UserFavoriteArtist
        {
            UserId = userId,
            ArtistId = artistId
        };

        await _context.Set<UserFavoriteArtist>().AddAsync(favorite);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveFavoriteArtistAsync(string userId, Guid artistId)
    {
        var favorite = await _context.Set<UserFavoriteArtist>()
            .FirstOrDefaultAsync(ufa => ufa.UserId == userId && ufa.ArtistId == artistId);

        if (favorite == null)
            return false;

        _context.Set<UserFavoriteArtist>().Remove(favorite);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> IsArtistFavoriteAsync(string userId, Guid artistId)
    {
        return await _context.Set<UserFavoriteArtist>()
            .AnyAsync(ufa => ufa.UserId == userId && ufa.ArtistId == artistId);
    }
}