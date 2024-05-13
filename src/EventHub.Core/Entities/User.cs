using EventHub.Core.Exceptions.Users;
using EventHub.Core.ValueObjects.Users;

namespace EventHub.Core.Entities;

public class User
{
    public UserId Id { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }

    public List<Event> HostedEvents { get; set; } = [];
    public List<Registration> Registrations { get; set; } = [];
    
    
    private User()
    {
    }

    private User(UserId id, Email email, Password password)
    {
        Id = id;
        Email = email;
        Password = password;
    }

    public static User Create(UserId id, Email email, Password password)
        => new User(id, email, password);
}