using ArtGallery.Application.Contracts;
using ArtGallery.Application.Contracts.Infrastructure;
using ArtGallery.Application.Specifications;
using ArtGallery.Domain.Entities;
using MediatR;

namespace ArtGallery.Application.Features.Artists.Commands;

public class DeleteArtistCommandHandler : IRequestHandler<DeleteArtistCommand, DeleteArtistCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageService _imageService;

    public DeleteArtistCommandHandler(IUnitOfWork unitOfWork, IImageService imageService)
    {
        _unitOfWork = unitOfWork;
        _imageService = imageService;
    }

    public async Task<DeleteArtistCommandResponse> Handle(DeleteArtistCommand request,
        CancellationToken cancellationToken)
    {
        var response = new DeleteArtistCommandResponse();

        try
        {
            var artist = await _unitOfWork.Repository<Artist>().GetByIdAsync(request.Id);

            if (artist == null)
            {
                throw new Exception(nameof(Artist));
            }

            await _unitOfWork.ExecuteWithTransactionAsync(async () =>
            {
                var artistImages = await _unitOfWork.Repository<ArtistImage>()
                    .ListAsync(new BaseSpecification<ArtistImage>(ai => ai.ArtistId == request.Id));

                foreach (var image in artistImages)
                {
                    if (!string.IsNullOrEmpty(image.PublicId))
                    {
                        await _imageService.DeleteImageAsync(image.PublicId);
                    }
                }
                
                //await _unitOfWork.Repository<Artist>().RemoveAsync(artist);
                await _unitOfWork.ArtistRepository.RemoveAsync(artist);
                
                await _unitOfWork.Complete();
            });

            response.Message = $"Artist {artist.FirstName} {artist.LastName} was successfully deleted.";
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"An error occurred while deleting the artist: {ex.Message}";
        }

        return response;
    }
}