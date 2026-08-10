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

    [Theory]
    [InlineData(1, "Hello, World!")]
    [InlineData(3, "Hello, World!\nHello, World!\nHello, World!")]
    public void Greet_WithCount_RepeatsGreeting(int count, string expectedWithUnixNewLines)
    {
        var expected = expectedWithUnixNewLines.Replace("\n", Environment.NewLine, StringComparison.Ordinal);

        var result = Greeter.Greet("World", count);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Greet_WithCount_ThrowsArgumentOutOfRangeException_WhenCountIsLessThanOne(int count)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Greeter.Greet("World", count));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Greet_WithCount_ThrowsArgumentException_WhenNameIsNullOrWhitespace(string name)
    {
        Assert.Throws<ArgumentException>(() => Greeter.Greet(name, 3));
    }
}
