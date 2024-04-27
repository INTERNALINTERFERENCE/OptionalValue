
using NUnit.Framework;

namespace OptionalValue.Tests;

public class OptionalValueTest
{
    private class Example
    {
        public OptionalValue<string> Property { get; init; }
    }
    
    [Test]
    public void HasValue_WhenValueIsPresent_ReturnsTrue()
    {
        // Arrange
        var optionalValue = new Example { Property = null };

        // Act
        var hasValue = optionalValue.Property.HasValue;

        // Assert
        Assert.That(hasValue, Is.True);
    }

    [Test]
    public void HasValue_WhenValueIsNotPresent_ReturnsFalse()
    {
        // Arrange
        var optionalValue = new Example();

        // Act
        var hasValue = optionalValue.Property.HasValue;

        // Assert
        Assert.That(hasValue, Is.False);
    }
}