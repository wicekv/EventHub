using EventHub.Core.Exceptions;

namespace EventHub.Application.Exceptions;

public class UserAlreadyRegisteredException : CustomException
{
    public UserAlreadyRegisteredException() : base($"You are already registered")
    {
    }
}