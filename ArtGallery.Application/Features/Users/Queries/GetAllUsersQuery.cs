using ArtGallery.Application.DTOs;
using MediatR;

namespace ArtGallery.Application.Features.Users.Queries;

public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
{
}