using EventHub.Core.Entities;

namespace EventHub.Core.Repositories;

public interface IEventRepository
{
    Task AddAsync(Event @event, CancellationToken cancellationToken);
}