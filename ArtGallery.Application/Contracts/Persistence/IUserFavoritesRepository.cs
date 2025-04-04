using ArtGallery.Domain.Entities;

namespace ArtGallery.Application.Contracts.Persistence;

public interface IUserFavoritesRepository
{
    Task<IReadOnlyList<UserFavoritePainting>> GetUserFavoritePaintingsAsync(string userId);
    Task<bool> AddFavoritePaintingAsync(string userId, Guid paintingId);
    Task<bool> RemoveFavoritePaintingAsync(string userId, Guid paintingId);
    Task<bool> IsPaintingFavoriteAsync(string userId, Guid paintingId);
    
    Task<IReadOnlyList<UserFavoriteArtist>> GetUserFavoriteArtistsAsync(string userId);
    Task<bool> AddFavoriteArtistAsync(string userId, Guid artistId);
    Task<bool> RemoveFavoriteArtistAsync(string userId, Guid artistId);
    Task<bool> IsArtistFavoriteAsync(string userId, Guid artistId);
}