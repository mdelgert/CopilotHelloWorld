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

        Assert.Equal(expected, Names.All.Select(person => person.Name));
    }

    [Fact]
    public void All_ContainsUniqueBirthdatesForEveryPerson()
    {
        Assert.All(Names.All, person => Assert.NotEqual(default, person.Birthdate));
        Assert.Equal(Names.All.Count, Names.All.Select(person => person.Birthdate).Distinct().Count());
    }
}
