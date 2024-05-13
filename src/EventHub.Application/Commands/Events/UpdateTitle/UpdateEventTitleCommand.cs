using MediatR;

namespace EventHub.Application.Commands.Events.UpdateTitle;

public record UpdateEventTitleCommand(Guid EventId, string Title) : IRequest;