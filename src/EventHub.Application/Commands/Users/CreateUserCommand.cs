using MediatR;

namespace EventHub.Application.Commands.Users;

public record CreateUserCommand(string Email, string Password) : IRequest<Guid>;