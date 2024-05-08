namespace EventHub.Core.Exceptions.Events;

public sealed class InvalidTitleException : CustomException
{
    public string Title { get; }

    public InvalidTitleException(string title) : base($"Title: '{title}' is invalid.")
    {
        Title = title;
    }
}