using EventHub.Application.Exceptions;
using EventHub.Application.Security;
using EventHub.Core.Entities;
using EventHub.Core.Repositories;
using MediatR;

namespace EventHub.Application.Commands.Users.CreateUser;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;
    
    public CreateUserCommandHandler(IUserRepository userRepository, IPasswordManager passwordManager)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByEmailAsync(request.Email, cancellationToken) is not null)
        {
            throw new EmailAlreadyExistsException(request.Email);
        }
        
        var securedPassword = _passwordManager.Secure(request.Password);

        var user = User.Create(Guid.NewGuid(),request.Email, securedPassword);
        
        await _userRepository.AddAsync(user, cancellationToken);

        return user.Id;
    }
}