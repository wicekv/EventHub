using MediatR;

namespace EventHub.Application.Commands.Users.CreateUser;

public record CreateUserCommand(string Email, string Password) : IRequest<Guid>;