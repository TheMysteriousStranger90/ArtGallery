using ArtGallery.Application.Contracts;
using ArtGallery.Application.Contracts.Infrastructure;
using ArtGallery.Application.DTOs;
using ArtGallery.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Paintings.Commands;

public class CreatePaintingCommandHandler : IRequestHandler<CreatePaintingCommand, CreatePaintingCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;

    public CreatePaintingCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IImageService imageService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _imageService = imageService;
    }

    public async Task<CreatePaintingCommandResponse> Handle(CreatePaintingCommand request,
        CancellationToken cancellationToken)
    {
        var response = new CreatePaintingCommandResponse();

        var validator = new CreatePaintingCommandValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return response;
        }

        try
        {
            Painting createdPainting = null;
            
            await _unitOfWork.ExecuteWithTransactionAsync(async () =>
            {
                var painting = new Painting
                {
                    Title = request.Title,
                    Description = request.Description,
                    CreationYear = request.CreationYear,
                    Medium = request.Medium,
                    Dimensions = request.Dimensions,
                    PaintType = request.PaintType,
                    ArtistId = request.ArtistId,
                    GenreId = request.GenreId,
                    MuseumId = request.MuseumId
                };
                
                string imageUrl = null;
                string publicId = null;

                if (request.Image != null)
                {
                    var imageUploadResult = await _imageService.AddImageAsync(request.Image);

                    if (imageUploadResult.Error != null)
                    {
                        throw new Exception($"Image upload failed: {imageUploadResult.Error.Message}");
                    }

                    imageUrl = imageUploadResult.SecureUrl.ToString();
                    publicId = imageUploadResult.PublicId;
                    painting.ImageUrl = imageUrl;
                }
                
                await _unitOfWork.Repository<Painting>().AddAsync(painting);
                
                await _unitOfWork.Complete();
                
                if (request.Image != null && !string.IsNullOrEmpty(imageUrl))
                {
                    var paintingImage = new PaintingImage
                    {
                        PictureUrl = imageUrl,
                        PublicId = publicId,
                        IsMain = true,
                        PaintingId = painting.Id
                    };

                    await _unitOfWork.Repository<PaintingImage>().AddAsync(paintingImage);
                }
                
                if (request.TagIds?.Any() == true)
                {
                    foreach (var tagId in request.TagIds)
                    {
                        var paintingTag = new PaintingTag
                        {
                            PaintingId = painting.Id,
                            TagId = tagId
                        };
                        await _unitOfWork.Repository<PaintingTag>().AddAsync(paintingTag);
                    }
                }
                
                await _unitOfWork.Complete();
                
                createdPainting = painting;
            });

            if (createdPainting != null)
            {
                var paintingWithDetails = await _unitOfWork.PaintingRepository.GetPaintingWithDetailsAsync(createdPainting.Id);
                response.Painting = _mapper.Map<PaintingDto>(paintingWithDetails);
            }
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"An error occurred while creating the painting: {ex.Message}";
        }

        return response;
    }
}