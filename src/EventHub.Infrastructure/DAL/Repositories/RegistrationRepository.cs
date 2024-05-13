using EventHub.Core.Entities;
using EventHub.Core.Repositories;
using EventHub.Core.ValueObjects.Events;
using EventHub.Core.ValueObjects.Registrations;
using EventHub.Core.ValueObjects.Users;
using Microsoft.EntityFrameworkCore;

namespace EventHub.Infrastructure.DAL.Repositories;

internal class RegistrationRepository : IRegistrationRepository
{
    private readonly EventHubDbContext _dbContext;

    public RegistrationRepository(EventHubDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Registration registration, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(registration, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    
    public async Task GetAsync(RegistrationId registrationId, CancellationToken cancellationToken)
    {
        await _dbContext.Registrations
            .SingleOrDefaultAsync(e => e.Id == registrationId, cancellationToken);
    }
    
    public async Task<bool> IsUserRegisteredForEventAsync(UserId userId, EventId eventId, CancellationToken cancellationToken)
    {
        return await _dbContext.Registrations
            .AnyAsync(r => r.UserId == userId && r.EventId == eventId, cancellationToken);
    }
}