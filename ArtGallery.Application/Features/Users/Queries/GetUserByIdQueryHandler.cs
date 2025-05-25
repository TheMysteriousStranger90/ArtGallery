using ArtGallery.Application.Contracts;
using ArtGallery.Application.Contracts.Identity;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ArtGallery.Application.Features.Users.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailDto>
    {
        private readonly IUserManagerService _userManagerService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetUserByIdQueryHandler> _logger;

        public GetUserByIdQueryHandler(
            IUserManagerService userManagerService,
            IUnitOfWork unitOfWork,
            ILogger<GetUserByIdQueryHandler> logger)
        {
            _userManagerService = userManagerService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<UserDetailDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Retrieving user details for ID: {UserId}", request.Id);

            var user = await _userManagerService.GetUserByIdAsync(request.Id);
            if (user == null)
            {
                throw new NotFoundException($"User with ID '{request.Id}' not found");
            }

            var roles = await _userManagerService.GetUserRolesAsync(user);
            var favoritePaintings = await _unitOfWork.UserFavoritesRepository.GetUserFavoritePaintingsAsync(user.Id);
            var favoriteArtists = await _unitOfWork.UserFavoritesRepository.GetUserFavoriteArtistsAsync(user.Id);

            return new UserDetailDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Created = user.Created,
                LastActive = user.LastActive,
                EmailConfirmed = user.EmailConfirmed,
                Roles = roles,
                FavoriteArtistsCount = favoriteArtists.Count,
                FavoritePaintingsCount = favoritePaintings.Count
            };
        }
    }
}