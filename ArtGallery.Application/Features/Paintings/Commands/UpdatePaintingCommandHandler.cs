using ArtGallery.Application.Contracts;
using ArtGallery.Application.Contracts.Infrastructure;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Exceptions;
using ArtGallery.Application.Specifications;
using ArtGallery.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Paintings.Commands
{
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
                await _unitOfWork.BeginTransactionAsync();

                var painting = await _unitOfWork.Repository<Painting>().GetByIdAsync(request.Id);

                if (painting == null)
                {
                    throw new Exception(nameof(Painting));
                }

                var existingMainImage = await _unitOfWork.Repository<PaintingImage>()
                    .GetByConditionAsync(pi => pi.PaintingId == request.Id && pi.IsMain);

                if (request.Image != null)
                {
                    var imageUploadResult = await _imageService.AddImageAsync(request.Image);

                    if (imageUploadResult.Error != null)
                    {
                        throw new Exception($"Image upload failed: {imageUploadResult.Error.Message}");
                    }

                    painting.ImageUrl = imageUploadResult.SecureUrl.ToString();

                    if (existingMainImage != null)
                    {
                        if (!string.IsNullOrEmpty(existingMainImage.PublicId))
                        {
                            await _imageService.DeleteImageAsync(existingMainImage.PublicId);
                        }

                        existingMainImage.PictureUrl = imageUploadResult.SecureUrl.ToString();
                        existingMainImage.PublicId = imageUploadResult.PublicId;
                        await _unitOfWork.Repository<PaintingImage>().UpdateAsync(existingMainImage);
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
                    painting.ImageUrl = null;
                }

                painting.Title = request.Title;
                painting.Description = request.Description;
                painting.CreationYear = request.CreationYear;
                painting.Medium = request.Medium;
                painting.Dimensions = request.Dimensions;
                painting.PaintType = request.PaintType;
                painting.ArtistId = request.ArtistId;
                painting.GenreId = request.GenreId;
                painting.MuseumId = request.MuseumId;

                await _unitOfWork.Repository<Painting>().UpdateAsync(painting);

                var existingTags = await _unitOfWork.Repository<PaintingTag>()
                    .ListAsync(new BaseSpecification<PaintingTag>(pt => pt.PaintingId == request.Id));

                foreach (var tag in existingTags)
                {
                    await _unitOfWork.Repository<PaintingTag>().RemoveAsync(tag);
                }

                foreach (var tagId in request.TagIds)
                {
                    var paintingTag = new PaintingTag
                    {
                        PaintingId = painting.Id,
                        TagId = tagId
                    };

                    await _unitOfWork.Repository<PaintingTag>().AddAsync(paintingTag);
                }

                await _unitOfWork.CommitTransactionAsync();

                var updatedPainting = await _unitOfWork.PaintingRepository.GetPaintingWithDetailsAsync(painting.Id);
                response.Painting = _mapper.Map<PaintingDto>(updatedPainting);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                response.Success = false;
                response.Message = $"An error occurred while updating the painting: {ex.Message}";
            }

            return response;
        }
    }
}