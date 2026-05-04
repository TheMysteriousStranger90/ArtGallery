using MediatR;

namespace ArtGallery.Application.Features.Artists.Queries;

public class GetUserFavoriteArtistsQuery : IRequest<UserFavoriteArtistsResponse>
{
    public string UserId { get; set; }
}