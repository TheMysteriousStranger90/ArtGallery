using ArtGallery.Application.Contracts;
using ArtGallery.Application.Contracts.Infrastructure;
using ArtGallery.Application.DTOs;
using ArtGallery.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Artists.Commands
{
    public class UpdateArtistCommandHandler : IRequestHandler<UpdateArtistCommand, UpdateArtistCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public UpdateArtistCommandHandler(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task<UpdateArtistCommandResponse> Handle(UpdateArtistCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateArtistCommandResponse();

            var validator = new UpdateArtistCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            try
            {
                await _unitOfWork.ExecuteWithTransactionAsync(async () =>
                {
                    //var artistToUpdate = await _unitOfWork.Repository<Artist>().GetByIdAsync(request.Id);
                    var artistToUpdate = await _unitOfWork.ArtistRepository.GetArtistWithPaintingsAsync(request.Id);
                    
                    if (artistToUpdate == null)
                    {
                        throw new Exception(nameof(Artist));
                    }
                    
                    var existingMainImage = await _unitOfWork.Repository<ArtistImage>()
                        .GetByConditionAsync(ai => ai.ArtistId == request.Id && ai.IsMain);
                    
                    if (request.Image != null)
                    {
                        var imageUploadResult = await _imageService.AddImageAsync(request.Image);
                        
                        if (imageUploadResult.Error != null)
                        {
                            throw new Exception($"Image upload failed: {imageUploadResult.Error.Message}");
                        }
                        
                        if (existingMainImage != null)
                        {
                            if (!string.IsNullOrEmpty(existingMainImage.PublicId))
                            {
                                await _imageService.DeleteImageAsync(existingMainImage.PublicId);
                            }
                            
                            existingMainImage.PictureUrl = imageUploadResult.SecureUrl.ToString();
                            existingMainImage.PublicId = imageUploadResult.PublicId;
                            await _unitOfWork.Repository<ArtistImage>().UpdateAsync(existingMainImage);
                        }
                        else
                        {
                            var artistImage = new ArtistImage
                            {
                                ArtistId = artistToUpdate.Id,
                                PictureUrl = imageUploadResult.SecureUrl.ToString(),
                                PublicId = imageUploadResult.PublicId,
                                IsMain = true
                            };
                            
                            await _unitOfWork.Repository<ArtistImage>().AddAsync(artistImage);
                        }
                    }
                    else if (!request.KeepExistingImage && existingMainImage != null)
                    {
                        if (!string.IsNullOrEmpty(existingMainImage.PublicId))
                        {
                            await _imageService.DeleteImageAsync(existingMainImage.PublicId);
                        }
                        
                        _unitOfWork.ImageRepository.RemoveArtistImage(existingMainImage);
                    }
                    
                    artistToUpdate.FirstName = request.FirstName;
                    artistToUpdate.LastName = request.LastName;
                    artistToUpdate.BirthDate = request.BirthDate;
                    artistToUpdate.DeathDate = request.DeathDate;
                    artistToUpdate.Nationality = request.Nationality;
                    
                    await _unitOfWork.Repository<Artist>().UpdateAsync(artistToUpdate);
                    
                    if (request.Biography != null)
                    {
                        var biography = await _unitOfWork.Repository<Biography>()
                            .GetByConditionAsync(b => b.ArtistId == request.Id);
                        
                        if (biography == null)
                        {
                            biography = new Biography
                            {
                                ArtistId = request.Id,
                                Content = request.Biography.Content,
                                ShortDescription = request.Biography.ShortDescription,
                                References = request.Biography.References
                            };
                            
                            await _unitOfWork.Repository<Biography>().AddAsync(biography);
                        }
                        else
                        {
                            biography.Content = request.Biography.Content;
                            biography.ShortDescription = request.Biography.ShortDescription;
                            biography.References = request.Biography.References;
                            
                            await _unitOfWork.Repository<Biography>().UpdateAsync(biography);
                        }
                    }
                    
                    await _unitOfWork.Complete();
                });

                var updatedArtist = await _unitOfWork.ArtistRepository.GetArtistWithPaintingsAsync(request.Id);
                response.Artist = _mapper.Map<ArtistDto>(updatedArtist);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred while updating the artist: {ex.Message}";
            }
            
            return response;
        }
    }
}