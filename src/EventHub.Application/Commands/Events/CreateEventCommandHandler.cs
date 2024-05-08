using EventHub.Core.Entities;
using EventHub.Core.Repositories;
using MediatR;

namespace EventHub.Application.Commands.Events;

internal sealed class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
{
    private readonly IEventRepository _eventRepository;
    private readonly IUserRepository _userRepository;

    public CreateEventCommandHandler(IEventRepository eventRepository, IUserRepository userRepository)
    {
        _eventRepository = eventRepository;
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(CreateEventCommand command, CancellationToken cancellationToken)
    {
        //TODO: pobieranie ID użytkownika z tokena
        var user = await _userRepository.GetUser(cancellationToken);
        
        if (user == null)
            throw new NotImplementedException();
        
        var @event = Event.Create(
            user.Id.Value, 
            command.Title, 
            command.Description, 
            command.Location,
            command.EventDate);

        await _eventRepository.AddAsync(@event, cancellationToken);

        return @event.Id;
    }
}