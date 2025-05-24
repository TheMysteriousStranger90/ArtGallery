using ArtGallery.Application.Contracts.Identity;
using ArtGallery.Application.Exceptions;
using ArtGallery.Application.Models.Authentication;
using ArtGallery.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ArtGallery.Application.Features.Authentication.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegistrationResponse>
    {
        private readonly IUserManagerService _userManagerService;
        private readonly IMediator _mediator;
        private readonly ILogger<RegisterCommandHandler> _logger;

        public RegisterCommandHandler(
            IUserManagerService userManagerService,
            IMediator mediator,
            ILogger<RegisterCommandHandler> logger)
        {
            _userManagerService = userManagerService;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<RegistrationResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Attempting to register user: {Email}", request.Email);

            var existingEmail = await _userManagerService.UserManager.FindByEmailAsync(request.Email);

            if (existingEmail != null)
            {
                _logger.LogWarning("Registration failed - email already exists: {Email}", request.Email);
                throw new BadRequestException($"Email {request.Email} already exists.");
            }

            var uniqueUsername = await GenerateUniqueUsernameAsync(request.FirstName, request.LastName);

            var user = new ApplicationUser
            {
                Email = request.Email.ToLower(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = uniqueUsername,
                EmailConfirmed = true
            };

            var result = await _userManagerService.CreateUserAsync(user, request.Password);

            if (!result)
            {
                _logger.LogError("Failed to create user: {Email}", request.Email);
                throw new BadRequestException("Failed to create user. Please check your information and try again.");
            }

            await _userManagerService.AddUserToRoleAsync(user, "User");

            var authenticateCommand = new AuthenticateCommand
            {
                Email = request.Email,
                Password = request.Password
            };

            var authResponse = await _mediator.Send(authenticateCommand, cancellationToken);

            _logger.LogInformation("User registered successfully: {Email}", request.Email);

            return new RegistrationResponse
            {
                Id = user.Id,
                Token = authResponse.Token,
                Email = user.Email,
                UserName = user.UserName
            };
        }

        private async Task<string> GenerateUniqueUsernameAsync(string firstName, string lastName)
        {
            string baseUsername = $"{firstName}{lastName}";
            string uniqueUsername;
            int attempts = 0;

            do
            {
                uniqueUsername = $"{baseUsername}{new Random().Next(100, 999)}".ToLower();
                attempts++;

                if (attempts > 10)
                {
                    _logger.LogError("Unable to generate unique username after 10 attempts for: {FirstName} {LastName}",
                        firstName, lastName);
                    throw new Exception("Unable to generate a unique username. Please try again.");
                }
            } while (await _userManagerService.UserExistsAsync(uniqueUsername));

            return uniqueUsername;
        }
    }
}