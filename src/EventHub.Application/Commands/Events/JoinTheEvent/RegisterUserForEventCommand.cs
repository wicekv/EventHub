using MediatR;

namespace EventHub.Application.Commands.Events.JoinTheEvent;

public record RegisterUserForEventCommand(Guid EventId) : IRequest<Guid>;
