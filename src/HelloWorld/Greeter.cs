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
}
