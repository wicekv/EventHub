using MediatR;

namespace EventHub.Application.Commands.User;

public record CreateUserCommand(string Email, string Password) : IRequest;