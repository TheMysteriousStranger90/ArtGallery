using ArtGallery.Application.Contracts;
using ArtGallery.Application.Contracts.Identity;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ArtGallery.Application.Features.Users.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailDto>
    {
        private readonly IUserManagerService _userManagerService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserByIdQueryHandler> _logger;

        public GetUserByIdQueryHandler(
            IUserManagerService userManagerService,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<GetUserByIdQueryHandler> logger)
        {
            _userManagerService = userManagerService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDetailDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManagerService.GetUserByIdAsync(request.Id);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            var roles = await _userManagerService.GetUserRolesAsync(user);
            var favoritePaintings = await _unitOfWork.UserFavoritesRepository.GetUserFavoritePaintingsAsync(request.Id);
            var favoriteArtists = await _unitOfWork.UserFavoritesRepository.GetUserFavoriteArtistsAsync(request.Id);

            var userDetail = _mapper.Map<UserDetailDto>(user);
            userDetail.Roles = roles.ToList();
            userDetail.FavoritePaintings = _mapper.Map<List<PaintingBriefDto>>(favoritePaintings);
            userDetail.FavoriteArtists = _mapper.Map<List<ArtistBriefDto>>(favoriteArtists);
            userDetail.FavoritePaintingsCount = favoritePaintings.Count;
            userDetail.FavoriteArtistsCount = favoriteArtists.Count;

            return userDetail;
        }
    }
}
