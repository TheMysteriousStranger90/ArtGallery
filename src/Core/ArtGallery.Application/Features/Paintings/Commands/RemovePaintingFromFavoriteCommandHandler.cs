using ArtGallery.Application.Contracts;
using MediatR;

namespace ArtGallery.Application.Features.Paintings.Commands;

public class RemovePaintingFromFavoriteCommandHandler
    : IRequestHandler<RemovePaintingFromFavoriteCommand, RemovePaintingFromFavoriteCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemovePaintingFromFavoriteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<RemovePaintingFromFavoriteCommandResponse> Handle(
        RemovePaintingFromFavoriteCommand request, CancellationToken cancellationToken)
    {
        var response = new RemovePaintingFromFavoriteCommandResponse();

        try
        {
            var result = await _unitOfWork.UserFavoritesRepository
                .RemoveFavoritePaintingAsync(request.UserId!, request.PaintingId);

            if (result)
            {
                response.Message = "Painting removed from favorites successfully";
            }
            else
            {
                response.Success = false;
                response.Message = "Painting was not in your favorites";
            }
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"An error occurred while removing the painting from favorites: {ex.Message}";
        }

        return response;
    }
}
