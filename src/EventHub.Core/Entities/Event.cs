namespace EventHub.Core.Entities;

public class Event
{
    public Guid Id { get; private set; }
    public Guid HostId { get;private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime EventDate { get; private set; }
    public string Location { get; private set; }
    
    public User Host { get; set; }
    public List<Registration> Registrations { get; set; }
    
    
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