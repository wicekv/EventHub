using EventHub.Core.ValueObjects.Events;
using EventHub.Core.ValueObjects.Registrations;
using EventHub.Core.ValueObjects.Users;

namespace EventHub.Core.Entities;

public class Registration
{
    public RegistrationId Id { get; set; }
    public UserId UserId { get; set; }
    public EventId EventId { get; set; }
    public DateTime RegistrationDate { get; set; }
    
    public User User { get; set; }
    public Event Event { get; set; }


    private Registration()
    {
    }

    private Registration(UserId userId, EventId eventId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        EventId = eventId;
    }

    public static Registration Create(UserId userId, EventId eventId)
        => new Registration(userId, eventId);
}