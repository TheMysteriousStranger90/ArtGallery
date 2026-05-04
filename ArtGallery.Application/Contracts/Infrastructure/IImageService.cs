using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace ArtGallery.Application.Contracts.Infrastructure;

public interface IImageService
{
    Task<ImageUploadResult> AddImageAsync(IFormFile file);
    Task<DeletionResult> DeleteImageAsync(string publicId);
}