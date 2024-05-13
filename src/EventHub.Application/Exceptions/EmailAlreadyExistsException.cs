using EventHub.Core.Exceptions;

namespace EventHub.Application.Exceptions;

public sealed class EmailAlreadyExistsException : CustomException
{
    public string Email { get; }

    public EmailAlreadyExistsException(string email) : base($"Email: '{email}' is already exist")
    {
        Email = email;
    }
}