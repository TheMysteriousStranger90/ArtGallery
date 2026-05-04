using ArtGallery.Application.Contracts;
using ArtGallery.Domain.Entities;
using MediatR;

namespace ArtGallery.Application.Features.Paintings.Commands;

public class
    AddPaintingToFavoriteCommandHandler : IRequestHandler<AddPaintingToFavoriteCommand,
    AddPaintingToFavoriteCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddPaintingToFavoriteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AddPaintingToFavoriteCommandResponse> Handle(
        AddPaintingToFavoriteCommand request, CancellationToken cancellationToken)
    {
        var response = new AddPaintingToFavoriteCommandResponse();

        try
        {
           //var painting = await _unitOfWork.Repository<Painting>().GetByIdAsync(request.PaintingId);
            var painting = await _unitOfWork.PaintingRepository.GetPaintingWithDetailsAsync(request.PaintingId);
            if (painting == null)
            {
                response.Success = false;
                response.Message = $"Painting with ID {request.PaintingId} not found";
                return response;
            }

            var result = await _unitOfWork.UserFavoritesRepository.AddFavoritePaintingAsync(
                request.UserId, request.PaintingId);

            if (result)
            {
                response.Success = true;
                response.IsFavorite = true;
                response.Message = "Painting added to favorites successfully";
            }
            else
            {
                response.Success = true;
                response.IsFavorite = true;
                response.Message = "Painting was already in favorites";
            }
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"An error occurred while adding the painting to favorites: {ex.Message}";
        }

        return response;
    }
}