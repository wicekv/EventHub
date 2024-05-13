using EventHub.Core.Exceptions;

namespace EventHub.Application.Exceptions;

public class UserNotFoundException : CustomException
{
    public UserNotFoundException() : base("User not found")
    {
    }
}