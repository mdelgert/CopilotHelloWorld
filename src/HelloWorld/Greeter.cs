namespace HelloWorld;

/// <summary>
/// Provides greeting functionality.
/// </summary>
internal sealed class Greeter
{
    /// <summary>
    /// Returns a greeting message for the specified name.
    /// </summary>
    /// <param name="name">The name to greet.</param>
    /// <returns>A greeting string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is empty or whitespace.</exception>
    public static string Greet(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        return $"Hello, {name}!";
    }

    /// <summary>
    /// Returns the greeting message for the specified name, repeated the given number of times,
    /// with each repetition on its own line.
    /// </summary>
    /// <param name="name">The name to greet.</param>
    /// <param name="count">The number of times to repeat the greeting. Must be at least 1.</param>
    /// <returns>The greeting, repeated <paramref name="count"/> times and separated by newlines.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is empty or whitespace.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="count"/> is less than 1.</exception>
    public static string Greet(string name, int count)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(count, 1);

        string greeting = Greet(name);
        return string.Join(Environment.NewLine, Enumerable.Repeat(greeting, count));
    }

    /// <summary>
    /// Returns a greeting message for the specified name that includes the given timestamp.
    /// </summary>
    /// <param name="name">The name to greet.</param>
    /// <param name="timestamp">The date and time to include in the greeting.</param>
    /// <returns>A greeting string that includes the timestamp.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is empty or whitespace.</exception>
    public static string Greet(string name, DateTimeOffset timestamp)
    {
        string greeting = Greet(name);
        return $"{greeting} The current time is {timestamp:yyyy-MM-dd HH:mm:ss zzz}.";
    }
}
