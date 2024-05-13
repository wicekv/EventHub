using MediatR;

namespace EventHub.Application.Commands.Users.LoginUser;

public record LoginUserCommand(string Email, string Password) : IRequest;
