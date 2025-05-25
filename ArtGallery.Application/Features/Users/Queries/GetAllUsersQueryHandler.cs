using ArtGallery.Application.Contracts;
using ArtGallery.Application.Contracts.Identity;
using ArtGallery.Application.DTOs;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ArtGallery.Application.Features.Users.Queries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserManagerService _userManagerService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetAllUsersQueryHandler> _logger;

        public GetAllUsersQueryHandler(
            IUserManagerService userManagerService,
            IUnitOfWork unitOfWork,
            ILogger<GetAllUsersQueryHandler> logger)
        {
            _userManagerService = userManagerService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Retrieving all users");

            var users = await _userManagerService.GetAllUsersAsync();
            var userDtos = new List<UserDto>();

            foreach (var user in users)
            {
                var favoritePaintings =
                    await _unitOfWork.UserFavoritesRepository.GetUserFavoritePaintingsAsync(user.Id);
                var favoriteArtists = await _unitOfWork.UserFavoritesRepository.GetUserFavoriteArtistsAsync(user.Id);
                var roles = await _userManagerService.GetUserRolesAsync(user);

                userDtos.Add(new UserDto
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
                });
            }

            _logger.LogInformation("Successfully retrieved {Count} users", userDtos.Count);
            return userDtos;
        }
    }
}