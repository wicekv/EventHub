using EventHub.Core.Entities;
using EventHub.Core.ValueObjects.Events;
using EventHub.Core.ValueObjects.Registrations;
using EventHub.Core.ValueObjects.Users;

namespace EventHub.Core.Repositories;

public interface IRegistrationRepository
{
    Task AddAsync(Registration registration, CancellationToken cancellationToken);
    Task GetAsync(RegistrationId registrationId, CancellationToken cancellationToken);
    Task<bool> IsUserRegisteredForEventAsync(UserId userId, EventId eventId, CancellationToken cancellationToken);
}