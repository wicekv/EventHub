using EventHub.Application.Commands.Events.CreateEvents;
using EventHub.Application.Exceptions;
using EventHub.Application.Security;
using EventHub.Core.Entities;
using EventHub.Core.Repositories;
using NSubstitute;
using Shouldly;

namespace EventHub.Application.Tests.Commands.Events;

public class CreateEventCommandHandlerTests
{
    private Task<Guid> Act(CreateEventCommand command) => _handler.Handle(command, default);

    [Fact]
    public async Task HandleAsync_Throws_UserNotFoundException_When_User_Does_Not_Exist()
    {
        // ARRANGE
        var command = new CreateEventCommand("Test Event", "Test Description", "Test Location", DateTime.UtcNow);
        
        _userRepository
            .GetByIdAsync(Guid.NewGuid(), default)
            .Returns((User?)null);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(command));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<UserNotFoundException>();
    }
    
    [Fact]
    public async Task Handle_GivenValidData_CreatesEventSuccessfully()
    {
        // ARRANGE
        var command = new CreateEventCommand("Test Event", "Test Description", "Test Location", DateTime.UtcNow);
        var userId = Guid.NewGuid();
        var user = User.Create(userId, "test@wp.pl", "strongpassword");
        
        _userRepository
            .GetByIdAsync(userId, default)
            .Returns(user);
        
        _user.GetCurrentUserId()
            .Returns(userId);
        
        _eventRepository
            .AddAsync(Arg.Any<Event>(), default)
            .Returns(Task.FromResult(Guid.NewGuid()));
        
        // ACT
        var result = await Act(command);

        // ASSERT
        result.ShouldNotBe(Guid.Empty);
        await _eventRepository.Received(1).AddAsync(Arg.Any<Event>(), default);
    }
    

    #region ARRANGE

    private readonly CreateEventCommandHandler _handler;
    private readonly IEventRepository _eventRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUser _user;

    public CreateEventCommandHandlerTests()
    {
        _eventRepository = Substitute.For<IEventRepository>();
        _userRepository = Substitute.For<IUserRepository>();
        _user = Substitute.For<IUser>();
        _handler = new CreateEventCommandHandler(_eventRepository, _userRepository, _user);
    }
    
    #endregion
}