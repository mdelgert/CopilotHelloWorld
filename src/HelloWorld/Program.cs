using System.Reflection;
using HelloWorld;

const int defaultRepeatCount = 3;
int repeatCount = args.Length > 0 && int.TryParse(args[0], out int parsedCount)
    ? parsedCount
    : defaultRepeatCount;

Version? version = Assembly.GetExecutingAssembly().GetName().Version;
Console.WriteLine($"HelloWorld v{version}");
Console.WriteLine(Greeter.Greet("World", repeatCount, DateTimeOffset.Now));

