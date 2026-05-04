using MediatR;

namespace ArtGallery.Application.Features.Paintings.Queries;

public class GetUserFavoritePaintingsQuery : IRequest<UserFavoritePaintingsResponse>
{
    public string UserId { get; set; }
}