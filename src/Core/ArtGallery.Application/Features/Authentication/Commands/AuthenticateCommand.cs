using ArtGallery.Application.Models.Authentication;
using MediatR;

namespace ArtGallery.Application.Features.Authentication.Commands;

public class AuthenticateCommand : IRequest<AuthenticationResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}