using ArtGallery.Application.Contracts.Identity;
using ArtGallery.Application.Features.Authentication.Commands;
using ArtGallery.Application.Models.Authentication;
using ArtGallery.Domain.Entities;
using MediatR;

namespace ArtGallery.Identity.Services
{
    public class AuthenticationService : IAuthenticationService 
    {
        private readonly IMediator _mediator;
        private readonly IUserManagerService _userManagerService;

        public AuthenticationService(IMediator mediator, IUserManagerService userManagerService)
        {
            _mediator = mediator;
            _userManagerService = userManagerService;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var command = new AuthenticateCommand
            {
                Email = request.Email,
                Password = request.Password
            };

            return await _mediator.Send(command);
        }

        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            var command = new RegisterCommand
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword
            };

            return await _mediator.Send(command);
        }
    }
}