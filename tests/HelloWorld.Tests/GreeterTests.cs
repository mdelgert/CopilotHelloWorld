using HelloWorld;

namespace HelloWorld.Tests;

public sealed class GreeterTests
{
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

    [Fact]
    public void Greet_ReturnsMessageContainingGreetingTimestampAndVersion()
    {
        var timestamp = new DateTimeOffset(2024, 3, 15, 9, 30, 0, TimeSpan.FromHours(-5));
        var version = new Version(1, 2, 3, 4);

        var result = Greeter.Greet("World", timestamp, version);

        Assert.Equal("Hello, World! The current time is 2024-03-15 09:30:00 -05:00. (v1.2.3.4)", result);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Greet_WithTimestampAndVersion_ThrowsArgumentException_WhenNameIsNullOrWhitespace(string name)
    {
        Assert.Throws<ArgumentException>(() => Greeter.Greet(name, DateTimeOffset.Now, new Version(1, 0)));
    }

    [Fact]
    public void Greet_WithTimestampAndVersion_ThrowsArgumentNullException_WhenVersionIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => Greeter.Greet("World", DateTimeOffset.Now, null!));
    }
}
