using EventHub.Core.Entities;
using EventHub.Core.ValueObjects.Users;

namespace EventHub.Core.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user, CancellationToken cancellationToken);
    Task<User?> GetByIdAsync(UserId userId, CancellationToken cancellationToken);
    Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken);
}