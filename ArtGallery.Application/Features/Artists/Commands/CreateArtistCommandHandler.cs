using ArtGallery.Application.Contracts;
using ArtGallery.Application.Contracts.Infrastructure;
using ArtGallery.Application.DTOs;
using ArtGallery.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Artists.Commands
{
    public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, CreateArtistCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public CreateArtistCommandHandler(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IImageService imageService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _imageService = imageService ?? throw new ArgumentNullException(nameof(imageService));
        }

        public async Task<CreateArtistCommandResponse> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateArtistCommandResponse();

            var validator = new CreateArtistCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            try
            {
                Artist createdArtist = null;
                
                await _unitOfWork.ExecuteWithTransactionAsync(async () =>
                {
                    var artist = new Artist
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        BirthDate = request.BirthDate,
                        DeathDate = request.DeathDate,
                        Nationality = request.Nationality
                    };
                    
                    await _unitOfWork.Repository<Artist>().AddAsync(artist);
                    
                    if (request.Biography != null)
                    {
                        var biography = new Biography
                        {
                            ArtistId = artist.Id,
                            Content = request.Biography.Content,
                            ShortDescription = request.Biography.ShortDescription,
                            References = request.Biography.References
                        };
                        
                        await _unitOfWork.Repository<Biography>().AddAsync(biography);
                    }

                    if (request.Image != null)
                    {
                        var imageUploadResult = await _imageService.AddImageAsync(request.Image);
                        
                        if (imageUploadResult.Error != null)
                        {
                            throw new Exception($"Image upload failed: {imageUploadResult.Error.Message}");
                        }
                        
                        var artistImage = new ArtistImage
                        {
                            ArtistId = artist.Id,
                            PictureUrl = imageUploadResult.SecureUrl.ToString(),
                            PublicId = imageUploadResult.PublicId,
                            IsMain = true
                        };
                        
                        await _unitOfWork.Repository<ArtistImage>().AddAsync(artistImage);
                    }
                    
                    await _unitOfWork.Complete();
                    
                    createdArtist = artist;
                });

                if (createdArtist != null)
                {
                    var artistWithDetails = await _unitOfWork.ArtistRepository.GetArtistWithPaintingsAsync(createdArtist.Id);
                    response.Artist = _mapper.Map<CreateArtistDto>(artistWithDetails);
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred while creating the artist: {ex.Message}";
            }
            
            return response;
        }
    }
}