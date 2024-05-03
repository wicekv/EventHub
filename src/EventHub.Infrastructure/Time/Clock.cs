using EventHub.Core.Abstractions;

namespace EventHub.Infrastructure.Time;

internal sealed class Clock : IClock
{
    public DateTime Current() => DateTime.UtcNow;
}