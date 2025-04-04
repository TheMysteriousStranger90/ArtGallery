using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ArtGallery.Application.Contracts.Identity;
using ArtGallery.Application.Exceptions;
using ArtGallery.Application.Helpers;
using ArtGallery.Application.Models.Authentication;
using ArtGallery.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ArtGallery.Identity.Services;

public class AuthenticationService : IAuthenticationService 
{
    private readonly IUserManagerService _userManagerService;
    private readonly JwtSettings _jwtSettings;

    public AuthenticationService(
        IOptions<JwtSettings> jwtSettings,
        IUserManagerService userManagerService)
    {
        _jwtSettings = jwtSettings.Value;
        _userManagerService = userManagerService;
    }

    public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
    {
        var user = await _userManagerService.UserManager.FindByEmailAsync(request.Email);
    
        if (user == null)
        {
            throw new UnauthorizedException("Invalid credentials");
        }
    
        var isPasswordValid = await _userManagerService.UserManager.CheckPasswordAsync(user, request.Password);
    
        if (!isPasswordValid)
        {
            throw new UnauthorizedException("Invalid credentials");
        }

        JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

        AuthenticationResponse response = new AuthenticationResponse
        {
            Id = user.Id,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Email = user.Email,
            UserName = user.UserName
        };
        
        return response;
    }

    public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
    {
        var existingEmail = await _userManagerService.UserManager.FindByEmailAsync(request.Email);
        
        if (existingEmail != null)
        {
            throw new BadRequestException($"Email {request.Email} already exists.");
        }
        
        string baseUsername = $"{request.FirstName}{request.LastName}";
        string uniqueUsername;
    
        int attempts = 0;
        do
        {
            uniqueUsername = $"{baseUsername}{new Random().Next(100, 999)}".ToLower();
            attempts++;
        
            if (attempts > 10)
                throw new Exception("Unable to generate a unique username. Please try again.");
            
        } while (await _userManagerService.UserExistsAsync(uniqueUsername));
        
        var user = new ApplicationUser
        {
            Email = request.Email.ToLower(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = uniqueUsername,
            EmailConfirmed = true
        };
        
        var result = await _userManagerService.CreateUserAsync(user, request.Password);

        if (result)
        {
            await _userManagerService.AddUserToRoleAsync(user, "User");
            
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
            
            return new RegistrationResponse {   
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName 
            };
        }
        else
        {
            throw new Exception("Failed to create user. Please check your information and try again.");
        }
    }

    private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
    {
        var userClaims = await _userManagerService.UserManager.GetClaimsAsync(user);
        var roles = await _userManagerService.GetUserRolesAsync(user);
        
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim(ClaimTypes.Role, role));
        }
        
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim("roles", role));
        }

        var claims = new[]
            {
                //new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
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
        
        return jwtSecurityToken;
    }
    
    public async Task<string> GenerateTokenAsync(ApplicationUser user)
    {
        var token = await GenerateToken(user);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}