using System.Data;
using EventHub.Core.ValueObjects.Events;
using EventHub.Core.ValueObjects.Users;

namespace EventHub.Core.Entities;

public class Event
{
    public EventId Id { get; private set; }
    public UserId HostId { get; set; }
    public Title Title { get; private set; }
    public Description Description { get; private set; }
    
    //TODO pomyślec nad polami prywatnymi
    public DateTime EventDate { get; private set; }
    public Location Location { get; private set; }
    
    public User Host { get; set; }
    public IEnumerable<Registration> Registrations { get; set; }
    
    
    private Event() { }

    private Event(EventId id, UserId hostId, Title title, Description description, Location location, DateTime eventDate)
    {
        Id = id;
        HostId = hostId;
        Title = title;
        Description = description;
        Location = location;
        EventDate = eventDate;
    }

    public static Event Create(EventId id, UserId hostId, Title title, Description description, Location location,
        DateTime eventDate)
    {
        if (eventDate < DateTime.UtcNow)
        {
            throw new NotImplementedException();
        }
        
        return new Event(id, hostId, title, description, location, eventDate);
    }
    
    public void UpdateTitle(Title title)
        => Title = title;
}