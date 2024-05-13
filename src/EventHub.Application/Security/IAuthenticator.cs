using EventHub.Application.DTO;

namespace EventHub.Application.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid userId);
}