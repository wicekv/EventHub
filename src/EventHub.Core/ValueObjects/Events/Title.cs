using EventHub.Core.Exceptions.Events;

namespace EventHub.Core.ValueObjects.Events;

public sealed record Title
{
    public string Value { get; }
        
    public Title(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 100 or < 3)
        {
            throw new InvalidTitleException(value);
        }
            
        Value = value;
    }

    public static implicit operator Title(string value) => value is null ? null : new Title(value);

    public static implicit operator string(Title value) => value?.Value;

    public override string ToString() => Value;
}