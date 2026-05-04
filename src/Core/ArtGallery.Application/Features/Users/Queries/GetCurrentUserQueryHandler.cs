using ArtGallery.Application.Contracts;
using ArtGallery.Application.Contracts.Identity;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ArtGallery.Application.Features.Users.Queries
{
    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, UserProfileDto>
    {
        private readonly IUserManagerService _userManagerService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetCurrentUserQueryHandler> _logger;

        public GetCurrentUserQueryHandler(
            IUserManagerService userManagerService,
            IUnitOfWork unitOfWork,
            ILogger<GetCurrentUserQueryHandler> logger)
        {
            _userManagerService = userManagerService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<UserProfileDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Retrieving current user profile for ID: {UserId}", request.UserId);

            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new UnauthorizedException("User identity cannot be determined");
            }

            var user = await _userManagerService.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            var roles = await _userManagerService.GetUserRolesAsync(user);
            var favoritePaintings = await _unitOfWork.UserFavoritesRepository.GetUserFavoritePaintingsAsync(request.UserId);
            var favoriteArtists = await _unitOfWork.UserFavoritesRepository.GetUserFavoriteArtistsAsync(request.UserId);

            return new UserProfileDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Created = user.Created,
                LastActive = user.LastActive,
                Roles = roles,
                FavoriteArtistsCount = favoriteArtists.Count,
                FavoritePaintingsCount = favoritePaintings.Count
            };
        }
    }
}