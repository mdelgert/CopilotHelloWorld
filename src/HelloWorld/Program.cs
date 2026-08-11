using System.Reflection;
using HelloWorld;

Version version = Assembly.GetExecutingAssembly().GetName().Version ?? new Version(0, 0, 0, 0);
foreach (string planet in Planets.All)
{
    Console.WriteLine(Greeter.Greet(planet, DateTimeOffset.Now, version));
}

foreach (string name in Names.All)
{
    Console.WriteLine(Greeter.Greet(name, DateTimeOffset.Now, version));
}

