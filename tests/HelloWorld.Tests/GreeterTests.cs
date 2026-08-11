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

    [Fact]
    public void Greet_WithTimestamp_ReturnsMessageContainingGreetingAndTimestamp()
    {
        var timestamp = new DateTimeOffset(2024, 3, 15, 9, 30, 0, TimeSpan.FromHours(-5));

        var result = Greeter.Greet("World", timestamp);

        Assert.Equal("Hello, World! The current time is 2024-03-15 09:30:00 -05:00.", result);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Greet_WithTimestamp_ThrowsArgumentException_WhenNameIsNullOrWhitespace(string name)
    {
        Assert.Throws<ArgumentException>(() => Greeter.Greet(name, DateTimeOffset.Now));
    }

    [Fact]
    public void Greet_WithTimestamp_ThrowsArgumentNullException_WhenNameIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => Greeter.Greet(null!, DateTimeOffset.Now));
    }

    [Fact]
    public void Greet_WithCountAndTimestamp_RepeatsTimestampedGreeting()
    {
        var timestamp = new DateTimeOffset(2024, 3, 15, 9, 30, 0, TimeSpan.FromHours(-5));
        var expectedLine = "Hello, World! The current time is 2024-03-15 09:30:00 -05:00.";
        var expected = string.Join(Environment.NewLine, expectedLine, expectedLine, expectedLine);

        var result = Greeter.Greet("World", 3, timestamp);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Greet_WithCountAndTimestamp_ThrowsArgumentOutOfRangeException_WhenCountIsLessThanOne(int count)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Greeter.Greet("World", count, DateTimeOffset.Now));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Greet_WithCountAndTimestamp_ThrowsArgumentException_WhenNameIsNullOrWhitespace(string name)
    {
        Assert.Throws<ArgumentException>(() => Greeter.Greet(name, 3, DateTimeOffset.Now));
    }

    [Fact]
    public void Greet_WithCountTimestampAndVersion_RepeatsVersionedGreeting()
    {
        var timestamp = new DateTimeOffset(2024, 3, 15, 9, 30, 0, TimeSpan.FromHours(-5));
        var version = new Version(1, 2, 3, 4);
        var expectedLine = "Hello, World! The current time is 2024-03-15 09:30:00 -05:00. (v1.2.3.4)";
        var expected = string.Join(Environment.NewLine, expectedLine, expectedLine, expectedLine);

        var result = Greeter.Greet("World", 3, timestamp, version);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Greet_WithCountTimestampAndVersion_ThrowsArgumentOutOfRangeException_WhenCountIsLessThanOne(int count)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Greeter.Greet("World", count, DateTimeOffset.Now, new Version(1, 0)));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Greet_WithCountTimestampAndVersion_ThrowsArgumentException_WhenNameIsNullOrWhitespace(string name)
    {
        Assert.Throws<ArgumentException>(() => Greeter.Greet(name, 3, DateTimeOffset.Now, new Version(1, 0)));
    }

    [Fact]
    public void Greet_WithCountTimestampAndVersion_ThrowsArgumentNullException_WhenVersionIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => Greeter.Greet("World", 3, DateTimeOffset.Now, null!));
    }
}
