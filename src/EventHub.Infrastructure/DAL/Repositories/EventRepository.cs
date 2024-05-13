using EventHub.Core.Entities;
using EventHub.Core.Repositories;
using EventHub.Core.ValueObjects.Events;
using Microsoft.EntityFrameworkCore;

namespace EventHub.Infrastructure.DAL.Repositories;

internal sealed class EventRepository : IEventRepository
{
    private readonly EventHubDbContext _dbContext;

    public EventRepository(EventHubDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Event @event, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(@event, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<Event?> GetAsync(EventId eventId, CancellationToken cancellationToken)
    {
        return await _dbContext.Events
            .SingleOrDefaultAsync(e => e.Id == eventId, cancellationToken);
    }
    
    public async Task UpdateAsync(Event @event, CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}