using ArtGallery.Application.Contracts.Infrastructure;
using ArtGallery.Application.Helpers;
using ArtGallery.Domain.Entities;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ArtGallery.Application.Contracts;

namespace ArtGallery.Infrastructure.Image;

public class ImageService : IImageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Cloudinary _cloudinary;

    public ImageService(IOptions<CloudinarySettings> config, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        var acc = new Account
        (
            config.Value.CloudName,
            config.Value.ApiKey,
            config.Value.ApiSecret
        );

        _cloudinary = new Cloudinary(acc);
    }
    
    public async Task<ArtistImage> GetArtistImageByIdAsync(Guid artistImageId)
    {
        var image = await _unitOfWork.ImageRepository.GetArtistPhotoByIdAsync(artistImageId);
        
        if (image == null)
        {
            throw new KeyNotFoundException($"Artist image with ID {artistImageId} not found");
        }
        
        return image;
    }

    public async Task<PaintingImage> GetPaintingImageByIdAsync(Guid paintingImageId)
    {
        var image = await _unitOfWork.ImageRepository.GetPaintingPhotoByIdAsync(paintingImageId);
        
        if (image == null)
        {
            throw new KeyNotFoundException($"Painting image with ID {paintingImageId} not found");
        }
        
        return image;
    }

    public async Task DeleteArtistImageByIdAsync(Guid artistImageId)
    {
        var image = await _unitOfWork.ImageRepository.GetArtistPhotoByIdAsync(artistImageId);
        
        if (image == null)
        {
            throw new KeyNotFoundException($"Artist image with ID {artistImageId} not found");
        }
        
        if (!string.IsNullOrEmpty(image.PublicId))
        {
            await DeleteImageAsync(image.PublicId);
        }
        
        _unitOfWork.ImageRepository.RemoveArtistImage(image);
        await _unitOfWork.Complete();
    }

    public async Task DeletePaintingImageByIdAsync(Guid paintingImageId)
    {
        var image = await _unitOfWork.ImageRepository.GetPaintingPhotoByIdAsync(paintingImageId);
        
        if (image == null)
        {
            throw new KeyNotFoundException($"Painting image with ID {paintingImageId} not found");
        }
        
        if (!string.IsNullOrEmpty(image.PublicId))
        {
            await DeleteImageAsync(image.PublicId);
        }
        
        _unitOfWork.ImageRepository.RemovePaintingImage(image);
        await _unitOfWork.Complete();
    }

    public async Task<ImageUploadResult> AddImageAsync(IFormFile file)
    {
        var uploadResult = new ImageUploadResult();

        if (file.Length > 0)
        {
            using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                Folder = "ArtGallery"
            };
            uploadResult = await _cloudinary.UploadAsync(uploadParams);
        }

        return uploadResult;
    }
    
    public async Task<DeletionResult> DeleteImageAsync(string publicId)
    {
        var deleteParams = new DeletionParams(publicId);

        return await _cloudinary.DestroyAsync(deleteParams);
    }
}