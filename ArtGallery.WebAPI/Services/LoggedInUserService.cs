using System.Security.Claims;
using ArtGallery.Application.Contracts;

namespace ArtGallery.WebAPI.Services;

public class LoggedInUserService : ILoggedInUserService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
    {
        _contextAccessor = httpContextAccessor;
    }

    public string UserId => _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) 
                            ?? _contextAccessor.HttpContext?.User?.FindFirstValue("uid");

    public string UserName => _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name) 
                              ?? _contextAccessor.HttpContext?.User?.Identity?.Name;

    public string Email => _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
    

    public IEnumerable<string> Roles
    {
        get
        {
            if (_contextAccessor.HttpContext == null || _contextAccessor.HttpContext.User == null)
                return new List<string>();

            return _contextAccessor.HttpContext.User.Claims
                .Where(c => c.Type == ClaimTypes.Role || c.Type == "roles")
                .Select(c => c.Value)
                .ToList();
        }
    }

    public bool IsAuthenticated => _contextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

    public string IpAddress => _contextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();

    public string UserAgent => _contextAccessor.HttpContext?.Request?.Headers["User-Agent"].ToString();

    public bool IsInRole(string roleName)
    {
        return _contextAccessor.HttpContext?.User?.IsInRole(roleName) ?? false;
    }

    public bool IsInAnyRole(params string[] roleNames)
    {
        if (_contextAccessor.HttpContext?.User == null) return false;
        
        return roleNames.Any(role => _contextAccessor.HttpContext.User.IsInRole(role));
    }

    public bool HasClaim(string claimType, string claimValue)
    {
        return _contextAccessor.HttpContext?.User?.HasClaim(claimType, claimValue) ?? false;
    }

    public string GetClaimValue(string claimType)
    {
        return _contextAccessor.HttpContext?.User?.FindFirstValue(claimType);
    }

    public IEnumerable<Claim> GetAllClaims()
    {
        return _contextAccessor.HttpContext?.User?.Claims ?? Enumerable.Empty<Claim>();
    }

    public Dictionary<string, string> GetRequestHeaders()
    {
        var headers = new Dictionary<string, string>();
        
        if (_contextAccessor.HttpContext?.Request?.Headers == null)
            return headers;
            
        foreach (var header in _contextAccessor.HttpContext.Request.Headers)
        {
            headers.Add(header.Key, header.Value);
        }
        
        return headers;
    }

    public DateTime? GetTokenExpirationTime()
    {
        var expClaim = _contextAccessor.HttpContext?.User?.FindFirstValue("exp");
        if (string.IsNullOrEmpty(expClaim)) return null;
        
        if (long.TryParse(expClaim, out long expSeconds))
        {
            return DateTimeOffset.FromUnixTimeSeconds(expSeconds).DateTime;
        }
        
        return null;
    }

    public int GetTokenTimeRemaining()
    {
        var expTime = GetTokenExpirationTime();
        if (expTime == null) return 0;
        
        var timeRemaining = expTime.Value - DateTime.UtcNow;
        return timeRemaining.TotalSeconds > 0 ? (int)timeRemaining.TotalSeconds : 0;
    }
}