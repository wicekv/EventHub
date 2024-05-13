using EventHub.Application.DTO;

namespace EventHub.Application.Security;

public interface ITokenStorage
{
    void Set(JwtDto jwt);
    JwtDto Get();
}