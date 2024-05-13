using EventHub.Core.Entities;
using EventHub.Core.Repositories;
using EventHub.Core.ValueObjects.Users;
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
    
    public async Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken)
    {
       return await _dbContext.Users
           .SingleOrDefaultAsync(x => x.Email == email, cancellationToken);    
    }

    public async Task<User?> GetByIdAsync(UserId userId, CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .SingleOrDefaultAsync(u => u.Id == userId, cancellationToken);
    }
}