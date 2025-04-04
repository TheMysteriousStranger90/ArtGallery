using ArtGallery.Domain.Entities;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace ArtGallery.Application.Contracts.Infrastructure;

public interface IImageService
{
    Task<ArtistImage> GetArtistImageByIdAsync(Guid artistImageId);
    Task<PaintingImage> GetPaintingImageByIdAsync(Guid paintingImageId);
    Task DeleteArtistImageByIdAsync(Guid artistImageId);
    Task DeletePaintingImageByIdAsync(Guid paintingImageId);
    Task<ImageUploadResult> AddImageAsync(IFormFile file);
    Task<DeletionResult> DeleteImageAsync(string publicId);
}