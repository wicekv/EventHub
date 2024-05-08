using EventHub.Core.Exceptions.Common;

namespace EventHub.Core.ValueObjects.Registrations;

public sealed class RegistrationId
{
    public Guid Value { get; }

    public RegistrationId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static implicit operator Guid(RegistrationId date) => date.Value;
    
    public static implicit operator RegistrationId(Guid value) => new(value); 
}