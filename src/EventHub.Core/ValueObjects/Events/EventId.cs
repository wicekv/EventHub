using EventHub.Core.Exceptions.Common;

namespace EventHub.Core.ValueObjects.Events;

public sealed record EventId
{
    public Guid Value { get; }

    public EventId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static implicit operator Guid(EventId date) => date.Value;
    
    public static implicit operator EventId(Guid value) => new(value); 
}