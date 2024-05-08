using EventHub.Core.ValueObjects.Registrations;

namespace EventHub.Core.Entities;

public class Registration
{
    public RegistrationId Id { get; set; }
    public Guid UserId { get; set; }
    public Guid EventId { get; set; }
    public DateTime RegistrationDate { get; set; }
    
    public User User { get; set; }
    public Event Event { get; set; }
}