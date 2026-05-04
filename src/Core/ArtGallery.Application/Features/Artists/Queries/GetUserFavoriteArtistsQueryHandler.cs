using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Artists.Queries;

public class GetUserFavoriteArtistsQueryHandler : IRequestHandler<GetUserFavoriteArtistsQuery, UserFavoriteArtistsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserFavoriteArtistsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserFavoriteArtistsResponse> Handle(GetUserFavoriteArtistsQuery request, CancellationToken cancellationToken)
    {
        var response = new UserFavoriteArtistsResponse();
            
        try
        {
            var favorites = await _unitOfWork.UserFavoritesRepository.GetUserFavoriteArtistsAsync(request.UserId);
                
            response.FavoriteArtists = _mapper.Map<List<ArtistDto>>(favorites.Select(f => f.Artist));
            response.Count = favorites.Count;
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"An error occurred while retrieving favorite artists: {ex.Message}";
        }
            
        return response;
    }
}