using ArtGallery.Application.Contracts;
using ArtGallery.Domain.Entities;
using MediatR;

namespace ArtGallery.Application.Features.Artists.Commands;

public class AddArtistToFavoriteCommandHandler : IRequestHandler<AddArtistToFavoriteCommand, AddArtistToFavoriteCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddArtistToFavoriteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AddArtistToFavoriteCommandResponse> Handle(
        AddArtistToFavoriteCommand request, CancellationToken cancellationToken)
    {
        var response = new AddArtistToFavoriteCommandResponse();

        try
        {
            var artist = await _unitOfWork.Repository<Artist>().GetByIdAsync(request.ArtistId);
            if (artist == null)
            {
                response.Success = false;
                response.Message = $"Artist with ID {request.ArtistId} not found";
                return response;
            }
            
            var result = await _unitOfWork.UserFavoritesRepository.AddFavoriteArtistAsync(
                request.UserId, request.ArtistId);

            if (result)
            {
                response.Success = true;
                response.IsFavorite = true;
                response.Message = "Artist added to favorites successfully";
            }
            else
            {
                response.Success = true;
                response.IsFavorite = true;
                response.Message = "Artist was already in favorites";
            }
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"An error occurred while adding the artist to favorites: {ex.Message}";
        }

        return response;
    }
}