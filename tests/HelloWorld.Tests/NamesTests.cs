namespace HelloWorld.Tests;

public sealed class NamesTests
{
    [Fact]
    public void All_ContainsExpectedNames()
    {
        string[] expected =
        [
            "Alice",
            "Bob",
            "Charlie",
            "Diana",
            "Ethan",
            "Fiona",
            "George",
            "Hannah",
        ];

        Assert.Equal(expected, Names.All);
    }
}
