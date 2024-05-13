using MediatR;

namespace EventHub.Application.Commands.Events.CreateEvents;

public sealed record CreateEventCommand(string Title, string Description, string Location, DateTime EventDate) : IRequest<Guid>;