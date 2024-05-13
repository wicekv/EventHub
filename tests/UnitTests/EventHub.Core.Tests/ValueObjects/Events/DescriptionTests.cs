using EventHub.Core.Exceptions.Events;
using EventHub.Core.ValueObjects.Events;
using Shouldly;

namespace EventHub.Core.Tests.ValueObjects.Events;

public class DescriptionTests
{
    [Theory]
    [InlineData("Valid description")]
    [InlineData("Enough chars")]
    public void Description_Constructor_Should_Accept_Valid_Inputs(string validDescription)
    {
        // Act
        var description = new Description(validDescription);

        // Assert
        description.Value.ShouldBe(validDescription);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("Ex")]
    [InlineData("A very long description that is clearly beyond one hundred characters, which should be too long for our system to handle properly.")]
    public void Description_Constructor_Should_Throw_When_Input_Is_Null_Or_Whitespace(string invalidDescription)
    {
        // Act & Assert
        Should.Throw<InvalidDescriptionException>(() => new Description(invalidDescription));
    }
    
    [Fact]
    public void Implicit_Conversion_From_String_To_Description_Should_Work()
    {
        // Arrange
        string value = "This is a valid description";

        // Act
        Description description = value;

        // Assert
        description.Value.ShouldBe(value);
    }

    [Fact]
    public void Implicit_Conversion_From_Description_To_String_Should_Work()
    {
        // Arrange
        var description = new Description("Another valid description");

        // Act
        string value = description;

        // Assert
        value.ShouldBe(description.Value);
    }

    [Fact]
    public void ToString_Should_Return_Correct_Value()
    {
        // Arrange
        var value = "Description for ToString test";
        var description = new Description(value);

        // Assert
        description.ToString().ShouldBe(value);
    }
}