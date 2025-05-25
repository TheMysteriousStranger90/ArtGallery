using ArtGallery.Application.DTOs;
using MediatR;

namespace ArtGallery.Application.Features.Users.Queries;

public class GetUserByIdQuery : IRequest<UserDetailDto>
{
    public string Id { get; set; }
}