using ArtGallery.Application.Contracts;
using ArtGallery.Application.Contracts.Infrastructure;
using ArtGallery.Application.DTOs;
using ArtGallery.Domain.Entities;
using AutoMapper;
using CloudinaryDotNet.Actions;
using MediatR;

namespace ArtGallery.Application.Features.Paintings.Commands;

public class UpdatePaintingCommandHandler : IRequestHandler<UpdatePaintingCommand, UpdatePaintingCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;

    public UpdatePaintingCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IImageService imageService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _imageService = imageService;
    }

    public async Task<UpdatePaintingCommandResponse> Handle(UpdatePaintingCommand request,
        CancellationToken cancellationToken)
    {
        var response = new UpdatePaintingCommandResponse();

        var validator = new UpdatePaintingCommandValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return response;
        }

        try
        {
            var painting = await _unitOfWork.PaintingRepository.GetPaintingWithDetailsAsync(request.Id);

            if (painting == null)
            {
                throw new Exception(nameof(Painting));
            }

            var existingMainImage = painting.PaintingImages.FirstOrDefault(pi => pi.IsMain);

            ImageUploadResult? imageUploadResult = null;
            if (request.Image != null)
            {
                imageUploadResult = await _imageService.AddImageAsync(request.Image);
                if (imageUploadResult.Error != null)
                {
                    throw new Exception($"Image upload failed: {imageUploadResult.Error.Message}");
                }
            }

            await _unitOfWork.ExecuteWithTransactionAsync(async () =>
            {
                if (request.Image != null && imageUploadResult != null)
                {
                    painting.ImageUrl = imageUploadResult.SecureUrl.ToString();

                    if (existingMainImage != null)
                    {
                        if (!string.IsNullOrEmpty(existingMainImage.PublicId))
                        {
                            await _imageService.DeleteImageAsync(existingMainImage.PublicId);
                        }

                        existingMainImage.PictureUrl = imageUploadResult.SecureUrl.ToString();
                        existingMainImage.PublicId = imageUploadResult.PublicId;
                    }
                    else
                    {
                        var paintingImage = new PaintingImage
                        {
                            PictureUrl = imageUploadResult.SecureUrl.ToString(),
                            PublicId = imageUploadResult.PublicId,
                            IsMain = true,
                            PaintingId = painting.Id
                        };

                        await _unitOfWork.Repository<PaintingImage>().AddAsync(paintingImage);
                    }
                }
                else if (!request.KeepExistingImage && existingMainImage != null)
                {
                    if (!string.IsNullOrEmpty(existingMainImage.PublicId))
                    {
                        await _imageService.DeleteImageAsync(existingMainImage.PublicId);
                    }

                    _unitOfWork.ImageRepository.RemovePaintingImage(existingMainImage);
                    painting.ImageUrl = null!;
                }

                painting.Title = request.Title!;
                painting.Description = request.Description!;
                painting.CreationYear = request.CreationYear;
                painting.Medium = request.Medium!;
                painting.Dimensions = request.Dimensions!;
                painting.PaintType = request.PaintType;
                painting.ArtistId = request.ArtistId;
                painting.GenreId = request.GenreId;
                painting.MuseumId = request.MuseumId;

                var existingTags = painting.Tags.ToList();
                foreach (var tag in existingTags)
                {
                    await _unitOfWork.Repository<PaintingTag>().RemoveAsync(tag);
                }

                foreach (var tagId in request.TagIds)
                {
                    var paintingTag = new PaintingTag { PaintingId = painting.Id, TagId = tagId };
                    await _unitOfWork.Repository<PaintingTag>().AddAsync(paintingTag);
                }

                await _unitOfWork.Complete();
            });

            var updatedPainting = await _unitOfWork.PaintingRepository.GetPaintingWithDetailsAsync(request.Id);
            response.Painting = _mapper.Map<PaintingDto>(updatedPainting);
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"An error occurred while updating the painting: {ex.Message}";
        }

        return response;
    }
}
