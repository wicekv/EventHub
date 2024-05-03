using EventHub.Core.Repositories;
using MediatR;

namespace EventHub.Application.Commands.User;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = Core.Entities.User.Create(request.Email, request.Password);
        
        await _userRepository.AddAsync(user, cancellationToken);

        return user.Id;
    }
}