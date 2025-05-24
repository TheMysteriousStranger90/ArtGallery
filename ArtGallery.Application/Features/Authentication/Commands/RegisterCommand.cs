using ArtGallery.Application.Models.Authentication;
using MediatR;

namespace ArtGallery.Application.Features.Authentication.Commands;

public class RegisterCommand : IRequest<RegistrationResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}