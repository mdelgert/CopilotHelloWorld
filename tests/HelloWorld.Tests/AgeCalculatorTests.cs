namespace HelloWorld.Tests;

public sealed class AgeCalculatorTests
{
    [Theory]
    [InlineData(1990, 4, 12, 2024, 4, 11, 33)] // day before birthday
    [InlineData(1990, 4, 12, 2024, 4, 12, 34)] // on birthday
    [InlineData(1990, 4, 12, 2024, 4, 13, 34)] // day after birthday
    [InlineData(2000, 2, 29, 2023, 2, 27, 22)] // leap-day birthdate, non-leap year
    [InlineData(2000, 2, 29, 2023, 2, 28, 23)] // AddYears clamps Feb 29 -> Feb 28
    [InlineData(2000, 2, 29, 2023, 3, 1, 23)]
    [InlineData(2024, 1, 1, 2024, 1, 1, 0)] // born today
    public void GetAge_ReturnsWholeYears(
        int birthYear, int birthMonth, int birthDay,
        int asOfYear, int asOfMonth, int asOfDay,
        int expectedAge)
    {
        var birthdate = new DateOnly(birthYear, birthMonth, birthDay);
        var asOf = new DateOnly(asOfYear, asOfMonth, asOfDay);

        Assert.Equal(expectedAge, AgeCalculator.GetAge(birthdate, asOf));
    }

    [Fact]
    public void GetAge_ThrowsArgumentOutOfRangeException_WhenBirthdateIsInTheFuture()
    {
        var asOf = new DateOnly(2024, 1, 1);
        var birthdate = asOf.AddDays(1);

        Assert.Throws<ArgumentOutOfRangeException>(() => AgeCalculator.GetAge(birthdate, asOf));
    }
}
