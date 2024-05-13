namespace EventHub.Application.DTO;

public class EventDto
{
    public string Title { get; init; } = null!;
    public string Description { get; init; } = null!;
    public DateTime EventDate { get; init; }
    public string Location { get; init; } = null!;
    public int NumberOfPeople { get; init; }
}