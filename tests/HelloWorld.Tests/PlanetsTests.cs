namespace HelloWorld.Tests;

public sealed class PlanetsTests
{
    [Fact]
    public void All_ContainsEightPlanetsInOrderFromTheSun()
    {
        string[] expected =
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

        Assert.Equal(expected, Planets.All);
    }
}
