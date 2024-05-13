using EventHub.Core.Entities;
using EventHub.Core.ValueObjects.Events;
using EventHub.Core.ValueObjects.Users;
using Shouldly;

namespace EventHub.Core.Tests.EventTests;

public class EventTests
{
    [Fact]
    public void CreateEvent_Should_Initialize_All_Properties_Correctly()
    {
        // Arrange
        var id = new EventId(Guid.NewGuid());
        var hostId = new UserId(Guid.NewGuid());
        var title = new Title("Networking Event");
        var description = new Description("Meet Developers");
        var location = new Location("Warsaw");
        var eventDate = DateTime.UtcNow.AddDays(30);

        // Act
        var eventEntity = Event.Create(id, hostId, title, description, location, eventDate);

        // Assert
        eventEntity.ShouldNotBeNull();
        eventEntity.Id.ShouldBe(id);
        eventEntity.HostId.ShouldBe(hostId);
        eventEntity.Title.ShouldBe(title);
        eventEntity.Description.ShouldBe(description);
        eventEntity.Location.ShouldBe(location);
        eventEntity.EventDate.ShouldBe(eventDate);
    }
    
    [Fact]
    public void UpdateTitle_Should_Change_Title_Correctly()
    {
        // Arrange
        var eventEntity = Event.Create(
            new EventId(Guid.NewGuid()), 
            new UserId(Guid.NewGuid()),
            new Title("Initial Event"),
            new Description("Initial Description"),
            new Location("Initial Location"),
            DateTime.UtcNow.AddDays(10));

        var newTitle = new Title("Updated Event Title");

        // Act
        eventEntity.UpdateTitle(newTitle);

        // Assert
        eventEntity.Title.ShouldBe(newTitle);
    }
}