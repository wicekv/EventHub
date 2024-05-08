using EventHub.Core.Entities;
using EventHub.Core.Repositories;

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
}