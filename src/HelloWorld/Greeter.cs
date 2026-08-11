using System.Reflection;

namespace HelloWorld;

/// <summary>
/// Provides greeting functionality.
/// </summary>
internal sealed class Greeter
{
    /// <summary>
    /// Returns a greeting message for the specified name, including the current timestamp and
    /// the application's version.
    /// </summary>
    /// <param name="name">The name to greet.</param>
    /// <returns>The timestamped, versioned greeting.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is empty or whitespace.</exception>
    public static string Greet(string name) => Greet(name, DateTimeOffset.Now, GetAssemblyVersion());

    /// <summary>
    /// Returns a greeting message for the specified name that includes the given timestamp and
    /// application version. Internal so tests can supply deterministic values.
    /// </summary>
    /// <param name="name">The name to greet.</param>
    /// <param name="timestamp">The date and time to include in the greeting.</param>
    /// <param name="version">The application version to include in the greeting.</param>
    /// <returns>The timestamped, versioned greeting.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> or <paramref name="version"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is empty or whitespace.</exception>
    internal static string Greet(string name, DateTimeOffset timestamp, Version version)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(version);

        return $"Hello, {name}! The current time is {timestamp:yyyy-MM-dd HH:mm:ss zzz}. (v{version})";
    }

    private static Version GetAssemblyVersion() =>
        Assembly.GetExecutingAssembly().GetName().Version ?? new Version(0, 0, 0, 0);
}
