namespace HelloWorld;

/// <summary>
/// Provides age calculation from birthdates.
/// </summary>
internal static class AgeCalculator
{
    /// <summary>
    /// Calculates a person's age in whole years as of today.
    /// </summary>
    /// <param name="birthdate">The person's birthdate.</param>
    /// <returns>The age in whole years.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="birthdate"/> is in the future.</exception>
    public static int GetAge(DateOnly birthdate) => GetAge(birthdate, DateOnly.FromDateTime(DateTime.Today));

    /// <summary>
    /// Calculates a person's age in whole years as of the specified date. Internal so tests
    /// can supply deterministic values.
    /// </summary>
    /// <param name="birthdate">The person's birthdate.</param>
    /// <param name="asOf">The date to calculate the age at.</param>
    /// <returns>The age in whole years.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="birthdate"/> is later than <paramref name="asOf"/>.</exception>
    internal static int GetAge(DateOnly birthdate, DateOnly asOf)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(birthdate, asOf);

        int age = asOf.Year - birthdate.Year;
        if (asOf < birthdate.AddYears(age))
        {
            age--;
        }

        return age;
    }
}
