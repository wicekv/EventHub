using EventHub.Application.Exceptions;
using EventHub.Application.Security;
using EventHub.Core.Entities;
using EventHub.Core.Repositories;
using MediatR;

namespace EventHub.Application.Commands.Events.JoinTheEvent;

public sealed class RegisterUserForEventCommandHandler : IRequestHandler<RegisterUserForEventCommand, Guid>
{
    private readonly IEventRepository _eventRepository;
    private readonly IRegistrationRepository _registrationRepository;
    private readonly IUser _user;
    
    public RegisterUserForEventCommandHandler(
        IEventRepository eventRepository, 
        IRegistrationRepository registrationRepository,
        IUser user)
    {
        _eventRepository = eventRepository;
        _registrationRepository = registrationRepository;
        _user = user;
    }
    
    //TODO może jakiś serwis domenowy?
    public async Task<Guid> Handle(RegisterUserForEventCommand request, CancellationToken cancellationToken)
    {
        if (await _eventRepository.GetAsync(request.EventId, cancellationToken) is null)
            throw new EventNotFoundException();

        var userId = _user.GetCurrentUserId();
        if (userId is null)
            throw new UserNotFoundException();

        if (await _registrationRepository.IsUserRegisteredForEventAsync(userId,request.EventId, cancellationToken))
            throw new UserAlreadyRegisteredException();
        
        var registration = Registration.Create(userId, request.EventId);
        
        await _registrationRepository.AddAsync(registration, cancellationToken);
        
        return registration.Id;
    }
}