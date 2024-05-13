namespace EventHub.Application.Security;

public interface IUser
{
    Guid? GetCurrentUserId();
}