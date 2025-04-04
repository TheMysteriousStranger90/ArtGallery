using ArtGallery.Domain.Entities;

namespace ArtGallery.Application.Contracts.Persistence;

public interface IImageRepository
{
    Task<ArtistImage> GetArtistPhotoByIdAsync(Guid artistImageId);
    Task<PaintingImage> GetPaintingPhotoByIdAsync(Guid paintingImageId);

    void RemoveArtistImage(ArtistImage image);
    void RemovePaintingImage(PaintingImage image);
}