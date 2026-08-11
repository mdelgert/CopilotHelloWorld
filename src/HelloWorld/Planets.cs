namespace HelloWorld;

/// <summary>
/// Provides the list of planets in the solar system.
/// </summary>
internal static class Planets
{
    /// <summary>
    /// Gets the names of the planets in the solar system, ordered by increasing distance from the Sun.
    /// </summary>
    public static IReadOnlyList<string> All { get; } =
    [
        "Mercury",
        "Venus",
        "Earth",
        "Mars",
        "Jupiter",
        "Saturn",
        "Uranus",
        "Neptune",
    ];
}
