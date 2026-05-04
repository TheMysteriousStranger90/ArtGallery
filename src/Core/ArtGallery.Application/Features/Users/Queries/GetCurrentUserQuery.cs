using ArtGallery.Application.DTOs;
using MediatR;

namespace ArtGallery.Application.Features.Users.Queries;

public class GetCurrentUserQuery : IRequest<UserProfileDto>
{
    public string UserId { get; set; }
}