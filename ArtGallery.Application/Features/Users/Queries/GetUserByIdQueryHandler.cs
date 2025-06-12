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
            var user = await _userManagerService.GetUserByIdAsync(request.Id);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            var roles = await _userManagerService.GetUserRolesAsync(user);
            var favoritePaintings = await _unitOfWork.UserFavoritesRepository.GetUserFavoritePaintingsAsync(request.Id);
            var favoriteArtists = await _unitOfWork.UserFavoritesRepository.GetUserFavoriteArtistsAsync(request.Id);

            var userDetail = new UserDetailDto
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

            foreach (var painting in favoritePaintings)
            {
                userDetail.FavoritePaintings.Add(new PaintingBriefDto
                {
                    Id = painting.Painting.Id,
                    Title = painting.Painting.Title,
                    ImageUrl = painting.Painting.ImageUrl,
                    Description = painting.Painting.Description,
                    CreationYear = painting.Painting.CreationYear,
                    Medium = painting.Painting.Medium,
                    Dimensions = painting.Painting.Dimensions,
                    PaintType = painting.Painting.PaintType,
                    
                    Artist = painting.Painting.Artist != null ? new ArtistBriefDto 
                    {
                        Id = painting.Painting.Artist.Id,
                        FirstName = painting.Painting.Artist.FirstName,
                        LastName = painting.Painting.Artist.LastName,
                        Nationality = painting.Painting.Artist.Nationality
                    } : null,
                });
            }
            
            foreach (var artist in favoriteArtists)
            {
                userDetail.FavoriteArtists.Add(new ArtistBriefDto
                {
                    Id = artist.Artist.Id,
                    FirstName = artist.Artist.FirstName,
                    LastName = artist.Artist.LastName,
                    Nationality = artist.Artist.Nationality
                });
            }

            return userDetail;
        }
    }
}