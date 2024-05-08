using EventHub.Core.ValueObjects.Events;

namespace EventHub.Core.Entities;

public class Event
{
    public EventId Id { get; private set; }
    public HostId HostId { get;private set; }
    public Title Title { get; private set; }
    public Description Description { get; private set; }
    public DateTime EventDate { get; private set; }
    public Location Location { get; private set; }
    
    public User Host { get; set; }
    public IEnumerable<Registration> Registrations { get; set; }
    
    
    private Event() { }

    private Event(Guid hostId, string title, string description, string location, DateTime eventDate)
    {
        HostId = hostId;
        Title = title;
        Description = description;
        Location = location;
        EventDate = eventDate;
    }
    
    public static Event Create(Guid hostId, string title, string description, string location, DateTime eventDate)
        => new Event(hostId, title, description, location, eventDate);
}