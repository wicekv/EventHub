using EventHub.Core.Exceptions.Common;

namespace EventHub.Core.ValueObjects.Events;

public sealed record HostId
{
    public Guid Value { get; }

    public HostId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static implicit operator Guid(HostId date) => date.Value;
    
    public static implicit operator HostId(Guid value) => new(value); 
}