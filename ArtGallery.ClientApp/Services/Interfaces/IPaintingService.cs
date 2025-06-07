using ArtGallery.ClientApp.Services; // For FileParameter and NSwag DTOs
using ArtGallery.ClientApp.Models; // If you create custom client-side models

namespace ArtGallery.ClientApp.Services.Interfaces
{
    public interface IPaintingService
    {
        Task<Pagination_1OfOfPaintingDtoAndApplicationAnd_0AndCulture_neutralAndPublicKeyToken_null> GetPaintingsAsync(
            int pageIndex = 1,
            int pageSize = 9,
            string search = "",
            Guid? artistId = null,
            Guid? genreId = null,
            Guid? museumId = null,
            PaintType? paintType = null,
            int? fromYear = null,
            int? toYear = null,
            string sort = "title",
            string apiVersion = "1.0");

        Task<PaintingDetailDto> GetPaintingAsync(Guid id, string apiVersion = "1.0");

        Task<PaintingDto> CreatePaintingAsync(
            string title,
            string description,
            int creationYear,
            string medium,
            string dimensions,
            FileParameter image,
            PaintType paintType,
            Guid artistId,
            Guid genreId,
            Guid museumId,
            IEnumerable<Guid> tagIds,
            string apiVersion = "1.0");

        Task<PaintingDto> UpdatePaintingAsync(
            Guid paintingId,
            Guid id,
            string title,
            string description,
            int creationYear,
            string medium,
            string dimensions,
            FileParameter? image,
            bool keepExistingImage,
            PaintType paintType,
            Guid artistId,
            Guid genreId,
            Guid museumId,
            IEnumerable<Guid> tagIds,
            string apiVersion = "1.0");

        Task<bool> DeletePaintingAsync(Guid id, string apiVersion = "1.0");
        Task<bool> AddPaintingToFavoritesAsync(Guid paintingId, string apiVersion = "1.0");
        Task<UserFavoritePaintingsResponse> GetFavoritePaintingsAsync(string apiVersion = "1.0");
    }
}