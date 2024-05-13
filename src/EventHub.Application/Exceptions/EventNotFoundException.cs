using EventHub.Core.Exceptions;

namespace EventHub.Application.Exceptions;

public class EventNotFoundException : CustomException
{
    public EventNotFoundException() : base("Event not found")
    {
    }
}