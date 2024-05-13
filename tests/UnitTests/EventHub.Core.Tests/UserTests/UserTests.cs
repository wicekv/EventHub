using EventHub.Core.Entities;
using EventHub.Core.Exceptions.Users;
using EventHub.Core.ValueObjects.Users;
using Shouldly;

namespace EventHub.Core.Tests.UserTests;

public class UserTests
{
    [Fact]
    public void CreateUser_Should_Set_Email_And_Password()
    {
        // Arrange
        var email = new Email("example@example.com");
        var password = new Password("strongpassword");
        var userId = new UserId(Guid.NewGuid());

        // Act
        var user = User.Create(userId, email, password);

        // Assert
        user.ShouldNotBeNull();
        user.Email.ShouldBe(email);
        user.Password.ShouldBe(password);
    }

    [Fact]
    public void CreateUser_Should_Initialize_Empty_HostedEvents_And_Registrations()
    {
        // Arrange
        var email = new Email("example@example.com");
        var password = new Password("strongpassword");
        var userId = new UserId(Guid.NewGuid());

        // Act
        var user = User.Create(userId, email, password);

        // Assert
        user.HostedEvents.ShouldBeEmpty();
        user.Registrations.ShouldBeEmpty();
    }
}