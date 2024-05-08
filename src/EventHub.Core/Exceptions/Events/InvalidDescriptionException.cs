namespace EventHub.Core.Exceptions.Events;

public class InvalidDescriptionException : CustomException
{
    public string Description { get; }

    public InvalidDescriptionException(string description) : base($"Title: '{description}' is invalid.")
    {
        Description = description;
    }
}