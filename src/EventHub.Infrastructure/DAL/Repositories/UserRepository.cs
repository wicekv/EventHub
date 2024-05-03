using EventHub.Core.Entities;
using EventHub.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventHub.Infrastructure.DAL.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly EventHubDbContext _dbContext;

    public UserRepository(EventHubDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}