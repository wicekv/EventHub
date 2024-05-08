using EventHub.Core.Entities;

namespace EventHub.Core.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user, CancellationToken cancellationToken);
    Task<User?> GetUser(CancellationToken cancellationToken);
}