namespace HelloWorld;

/// <summary>
/// Represents a sample person with a name and birthdate.
/// </summary>
/// <param name="Name">The person's name.</param>
/// <param name="Birthdate">The person's birthdate.</param>
internal sealed record Person(string Name, DateOnly Birthdate);

/// <summary>
/// Provides a collection of random sample names with birthdates.
/// </summary>
internal static class Names
{
    /// <summary>
    /// Gets a collection of random sample people, each with a name and birthdate.
    /// </summary>
    public static IReadOnlyList<Person> All { get; } =
    [
        new("Alice", new DateOnly(1990, 4, 12)),
        new("Bob", new DateOnly(1985, 11, 3)),
        new("Charlie", new DateOnly(1998, 7, 22)),
        new("Diana", new DateOnly(1992, 1, 30)),
        new("Ethan", new DateOnly(2000, 9, 15)),
        new("Fiona", new DateOnly(1987, 3, 8)),
        new("George", new DateOnly(1995, 6, 19)),
        new("Hannah", new DateOnly(1993, 12, 25)),
    ];
}
