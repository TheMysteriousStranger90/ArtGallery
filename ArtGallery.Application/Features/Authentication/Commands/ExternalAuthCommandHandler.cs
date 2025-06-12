using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ArtGallery.Application.Contracts.Identity;
using ArtGallery.Application.Helpers;
using ArtGallery.Application.Models.Authentication;
using ArtGallery.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ArtGallery.Application.Features.Authentication.Commands
{
    public class ExternalAuthCommandHandler : IRequestHandler<ExternalAuthCommand, ExternalAuthResponse>
    {
        private readonly IUserManagerService _userManagerService;
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger<ExternalAuthCommandHandler> _logger;

        public ExternalAuthCommandHandler(
            IUserManagerService userManagerService,
            IOptions<JwtSettings> jwtSettings,
            ILogger<ExternalAuthCommandHandler> logger)
        {
            _userManagerService = userManagerService;
            _jwtSettings = jwtSettings.Value;
            _logger = logger;
        }

        public async Task<ExternalAuthResponse> Handle(ExternalAuthCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Processing external authentication for provider: {Provider}, Email: {Email}", 
                request.Provider, request.Email);

            var user = await _userManagerService.UserManager.FindByEmailAsync(request.Email);
            bool isNewUser = false;

            if (user == null)
            {
                isNewUser = true;
                var uniqueUsername = await GenerateUniqueUsernameAsync(request.FirstName, request.LastName);

                user = new ApplicationUser
                {
                    Email = request.Email.ToLower(),
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserName = uniqueUsername,
                    EmailConfirmed = true
                };

                var createResult = await _userManagerService.UserManager.CreateAsync(user);
                if (!createResult.Succeeded)
                {
                    _logger.LogError("Failed to create user via external auth: {Errors}", 
                        string.Join(", ", createResult.Errors.Select(e => e.Description)));
                    throw new Exception("Failed to create user account");
                }

                await _userManagerService.AddUserToRoleAsync(user, "User");
                _logger.LogInformation("Created new user via external auth: {Email}", request.Email);
            }

            var existingLogin = await _userManagerService.UserManager.FindByLoginAsync(request.Provider, request.ExternalId);
            if (existingLogin == null)
            {
                var loginInfo = new Microsoft.AspNetCore.Identity.UserLoginInfo(request.Provider, request.ExternalId, request.Provider);
                var addLoginResult = await _userManagerService.UserManager.AddLoginAsync(user, loginInfo);
                
                if (!addLoginResult.Succeeded)
                {
                    _logger.LogWarning("Failed to add external login for user: {Email}", request.Email);
                }
            }

            var jwtToken = await GenerateTokenAsync(user);
            
            user.LastActive = DateTime.UtcNow;
            await _userManagerService.UserManager.UpdateAsync(user);

            _logger.LogInformation("External authentication successful for: {Email}", request.Email);

            return new ExternalAuthResponse
            {
                Id = user.Id,
                Token = jwtToken,
                Email = user.Email,
                UserName = user.UserName,
                Provider = request.Provider,
                IsNewUser = isNewUser
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

        private async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            var userClaims = await _userManagerService.UserManager.GetClaimsAsync(user);
            var roles = await _userManagerService.GetUserRolesAsync(user);
            
            var roleClaims = new List<Claim>();
            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
                roleClaims.Add(new Claim("roles", role));
            }

            var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("uid", user.Id),
                    new Claim("first_name", user.FirstName),
                    new Claim("last_name", user.LastName)
                }
                .Union(userClaims)
                .Union(roleClaims);
            
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}