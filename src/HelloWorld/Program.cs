using System.Reflection;
using HelloWorld;

const int defaultRepeatCount = 3;
int repeatCount = args.Length > 0 && int.TryParse(args[0], out int parsedCount)
    ? parsedCount
    : defaultRepeatCount;

Version version = Assembly.GetExecutingAssembly().GetName().Version ?? new Version(0, 0, 0, 0);
foreach (string planet in Planets.All)
{
    Console.WriteLine(Greeter.Greet(planet, repeatCount, DateTimeOffset.Now, version));
}

