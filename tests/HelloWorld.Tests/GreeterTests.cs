using HelloWorld;

namespace HelloWorld.Tests;

public sealed class GreeterTests
{
    [Theory]
    [InlineData("World", "Hello, World!")]
    [InlineData("Alice", "Hello, Alice!")]
    [InlineData("Bob", "Hello, Bob!")]
    public void Greet_ReturnsExpectedMessage(string name, string expected)
    {
        var result = Greeter.Greet(name);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Greet_ThrowsArgumentException_WhenNameIsNullOrWhitespace(string name)
    {
        Assert.Throws<ArgumentException>(() => Greeter.Greet(name));
    }

    [Fact]
    public void Greet_ThrowsArgumentNullException_WhenNameIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => Greeter.Greet(null!));
    }
}
