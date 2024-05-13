using EventHub.Application.Exceptions;
using EventHub.Application.Security;
using EventHub.Core.Repositories;
using MediatR;

namespace EventHub.Application.Commands.Users.LoginUser;

public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticator _authenticator;
    private readonly IPasswordManager _passwordManager;
    private readonly ITokenStorage _tokenStorage;


    public LoginUserCommandHandler(
        IUserRepository userRepository, 
        IAuthenticator authenticator, 
        IPasswordManager passwordManager, 
        ITokenStorage tokenStorage)
    {
        _userRepository = userRepository;
        _authenticator = authenticator;
        _passwordManager = passwordManager;
        _tokenStorage = tokenStorage;
    }

    public async Task Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (user is null)
        {
            throw new InvalidCredentialsException();
        }
        
        if (!_passwordManager.Validate(request.Password, user.Password))
        {
            throw new InvalidCredentialsException();
        }
        
        var jwt = _authenticator.CreateToken(user.Id);
        _tokenStorage.Set(jwt);
    }
}