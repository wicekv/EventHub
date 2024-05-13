using EventHub.Application.Exceptions;
using EventHub.Application.Security;
using EventHub.Core.Entities;
using EventHub.Core.Repositories;
using EventHub.Core.ValueObjects.Events;
using EventHub.Core.ValueObjects.Users;
using MediatR;

namespace EventHub.Application.Commands.Events.CreateEvents;

public sealed class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
{
    private readonly IEventRepository _eventRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUser _user;
    
    public CreateEventCommandHandler(IEventRepository eventRepository, IUserRepository userRepository, IUser user)
    {
        _eventRepository = eventRepository;
        _userRepository = userRepository;
        _user = user;
    }

    public async Task<Guid> Handle(CreateEventCommand command, CancellationToken cancellationToken)
    {
        var userId = _user.GetCurrentUserId();
        var user = await _userRepository.GetByIdAsync(userId!, cancellationToken);
        
        if (user == null)
            throw new UserNotFoundException();
        
        var @event = Event.Create(
            Guid.NewGuid(),
            new UserId(user.Id.Value), 
            new Title(command.Title), 
            new Description(command.Description), 
            new Location(command.Location),
            command.EventDate);

        await _eventRepository.AddAsync(@event, cancellationToken);

        return @event.Id;
    }
}