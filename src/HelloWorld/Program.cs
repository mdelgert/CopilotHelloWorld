using HelloWorld;

foreach (Person person in Names.All)
{
    Console.WriteLine(Greeter.Greet(person.Name));
    Console.WriteLine($"  Birthdate: {person.Birthdate:yyyy-MM-dd} (age {AgeCalculator.GetAge(person.Birthdate)})");
}

