using EventHub.Application.DTO;
using MediatR;

namespace EventHub.Application.Queries.Events;

public sealed record GetRegisteredEventsQuery : IRequest<IEnumerable<EventDto>>;
