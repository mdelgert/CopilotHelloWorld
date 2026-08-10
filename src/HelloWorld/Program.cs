using HelloWorld;

const int defaultRepeatCount = 3;
int repeatCount = args.Length > 0 && int.TryParse(args[0], out int parsedCount)
    ? parsedCount
    : defaultRepeatCount;

Console.WriteLine(Greeter.Greet("World", repeatCount));

