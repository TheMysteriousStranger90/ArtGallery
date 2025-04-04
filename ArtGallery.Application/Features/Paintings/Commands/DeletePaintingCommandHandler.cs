using ArtGallery.Application.Contracts;
using ArtGallery.Application.Contracts.Infrastructure;
using ArtGallery.Application.Exceptions;
using ArtGallery.Application.Specifications;
using ArtGallery.Domain.Entities;
using MediatR;

namespace ArtGallery.Application.Features.Paintings.Commands;

public class DeletePaintingCommandHandler : IRequestHandler<DeletePaintingCommand, DeletePaintingCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageService _imageService;

    public DeletePaintingCommandHandler(IUnitOfWork unitOfWork, IImageService imageService)
    {
        _unitOfWork = unitOfWork;
        _imageService = imageService;
    }

    public async Task<DeletePaintingCommandResponse> Handle(DeletePaintingCommand request,
        CancellationToken cancellationToken)
    {
        var response = new DeletePaintingCommandResponse();

        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var painting = await _unitOfWork.Repository<Painting>().GetByIdAsync(request.Id);

            if (painting == null)
            {
                throw new Exception(nameof(Painting));
            }
            
            var paintingImages = await _unitOfWork.Repository<PaintingImage>()
                .ListAsync(new BaseSpecification<PaintingImage>(pi => pi.PaintingId == request.Id));

            foreach (var image in paintingImages)
            {
                if (!string.IsNullOrEmpty(image.PublicId))
                {
                    await _imageService.DeleteImageAsync(image.PublicId);
                }
            }
            
            await _unitOfWork.Repository<Painting>().RemoveAsync(painting);
            await _unitOfWork.CommitTransactionAsync();

            response.Message = $"Painting {painting.Title} was successfully deleted.";
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            response.Success = false;
            response.Message = $"An error occurred while deleting the painting: {ex.Message}";
        }

        return response;
    }
}