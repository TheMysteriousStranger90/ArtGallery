using ArtGallery.Application.Contracts;
using MediatR;

namespace ArtGallery.Application.Features.Artists.Commands;

public class RemoveArtistFromFavoriteCommandHandler
    : IRequestHandler<RemoveArtistFromFavoriteCommand, RemoveArtistFromFavoriteCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveArtistFromFavoriteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<RemoveArtistFromFavoriteCommandResponse> Handle(
        RemoveArtistFromFavoriteCommand request, CancellationToken cancellationToken)
    {
        var response = new RemoveArtistFromFavoriteCommandResponse();

        try
        {
            var result = await _unitOfWork.UserFavoritesRepository
                .RemoveFavoriteArtistAsync(request.UserId!, request.ArtistId);

            if (result)
            {
                response.Message = "Artist removed from favorites successfully";
            }
            else
            {
                response.Success = false;
                response.Message = "Artist was not in your favorites";
            }
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"An error occurred while removing the artist from favorites: {ex.Message}";
        }

        return response;
    }
}
