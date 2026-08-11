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

    /// <summary>
    /// Returns a greeting message for the specified name that includes the given timestamp and
    /// application version.
    /// </summary>
    /// <param name="name">The name to greet.</param>
    /// <param name="timestamp">The date and time to include in the greeting.</param>
    /// <param name="version">The application version to include in the greeting.</param>
    /// <returns>The timestamped, versioned greeting.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> or <paramref name="version"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is empty or whitespace.</exception>
    public static string Greet(string name, DateTimeOffset timestamp, Version version)
    {
        ArgumentNullException.ThrowIfNull(version);

        return $"{Greet(name, timestamp)} (v{version})";
    }
}
