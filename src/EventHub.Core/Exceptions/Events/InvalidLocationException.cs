namespace EventHub.Core.Exceptions.Events;

public sealed class InvalidLocationException : CustomException
{
    public string Location { get; }
    public InvalidLocationException(string location) : base($"Location: '{location}' is invalid.")
    {
        Location = location;
    }
}