using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EventHub.Application.Security;
using Microsoft.AspNetCore.Http;

namespace EventHub.Infrastructure.Security;

public class User : IUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public User(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? GetCurrentUserId()
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value 
                          ?? _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

        if (userIdClaim != null && Guid.TryParse(userIdClaim, out Guid userId))
        {
            return userId;
        }

        return null;
    }
}
