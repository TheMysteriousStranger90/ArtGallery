using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ArtGallery.Application.Contracts.Identity;
using ArtGallery.Application.Exceptions;
using ArtGallery.Application.Helpers;
using ArtGallery.Application.Models.Authentication;
using ArtGallery.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ArtGallery.Application.Features.Authentication.Commands
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, AuthenticationResponse>
    {
        private readonly IUserManagerService _userManagerService;
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger<AuthenticateCommandHandler> _logger;

        public AuthenticateCommandHandler(
            IUserManagerService userManagerService,
            IOptions<JwtSettings> jwtSettings,
            ILogger<AuthenticateCommandHandler> logger)
        {
            _userManagerService = userManagerService;
            _jwtSettings = jwtSettings.Value;
            _logger = logger;
        }

        public async Task<AuthenticationResponse> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Attempting to authenticate user: {Email}", request.Email);

            var user = await _userManagerService.UserManager.FindByEmailAsync(request.Email);
            
            if (user == null)
            {
                _logger.LogWarning("Authentication failed - user not found: {Email}", request.Email);
                throw new UnauthorizedException("Invalid credentials");
            }

            var isPasswordValid = await _userManagerService.UserManager.CheckPasswordAsync(user, request.Password);
            
            if (!isPasswordValid)
            {
                _logger.LogWarning("Authentication failed - invalid password for user: {Email}", request.Email);
                throw new UnauthorizedException("Invalid credentials");
            }

            var jwtToken = await GenerateTokenAsync(user);
            
            user.LastActive = DateTime.UtcNow;
            await _userManagerService.UserManager.UpdateAsync(user);
            
            _logger.LogInformation("User authenticated successfully: {Email}", request.Email);

            return new AuthenticationResponse
            {
                Id = user.Id,
                Token = jwtToken,
                Email = user.Email,
                UserName = user.UserName
            };
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