using EventHub.Application.Exceptions;
using EventHub.Application.Security;
using EventHub.Core.Repositories;
using MediatR;

namespace EventHub.Application.Commands.Events.UpdateTitle;

public sealed class UpdateEventTitleCommandHandler : IRequestHandler<UpdateEventTitleCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IEventRepository _eventRepository;
    private readonly IUser _user;

    public UpdateEventTitleCommandHandler(IUserRepository userRepository, IEventRepository eventRepository, IUser user)
    {
        _userRepository = userRepository;
        _eventRepository = eventRepository;
        _user = user;
    }

    public async Task Handle(UpdateEventTitleCommand request, CancellationToken cancellationToken)
    {
        var eventUpdate = await _eventRepository.GetAsync(request.EventId, cancellationToken);

        if (eventUpdate is null)
            throw new EventNotFoundException();

        eventUpdate.UpdateTitle(request.Title);

        await _eventRepository.UpdateAsync(eventUpdate, cancellationToken);
    }
}