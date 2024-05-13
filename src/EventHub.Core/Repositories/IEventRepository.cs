using EventHub.Core.Entities;
using EventHub.Core.ValueObjects.Events;

namespace EventHub.Core.Repositories;

public interface IEventRepository
{
    Task AddAsync(Event @event, CancellationToken cancellationToken);
    Task<Event?> GetAsync(EventId eventId, CancellationToken cancellationToken);
    Task UpdateAsync(Event @event, CancellationToken cancellationToken);
}