using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Paintings.Queries;

public class GetUserFavoritePaintingsQueryHandler : IRequestHandler<GetUserFavoritePaintingsQuery, UserFavoritePaintingsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserFavoritePaintingsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserFavoritePaintingsResponse> Handle(GetUserFavoritePaintingsQuery request, CancellationToken cancellationToken)
    {
        var response = new UserFavoritePaintingsResponse();
        
        var favorites = await _unitOfWork.UserFavoritesRepository.GetUserFavoritePaintingsAsync(request.UserId);
        
        response.FavoritePaintings = _mapper.Map<List<PaintingDto>>(favorites.Select(f => f.Painting));
        response.Count = favorites.Count;
        
        return response;
    }
}