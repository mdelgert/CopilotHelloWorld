# CopilotHelloWorld

A .NET 10 C# Hello World console application built using best practices.

## Project Structure

```
CopilotHelloWorld.sln
├── src/
│   └── HelloWorld/          # Console application
│       ├── Program.cs        # Entry point (top-level statements)
│       └── Greeter.cs        # Greeting logic
└── tests/
    └── HelloWorld.Tests/    # xUnit test project
        └── GreeterTests.cs
```

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

## Getting Started

### Build

```bash
dotnet build
```

### Run

```bash
dotnet run --project src/HelloWorld
```

### Test

```bash
dotnet test
```

## Best Practices Applied

- **Top-level statements** – minimal boilerplate entry point
- **Nullable reference types** enabled to eliminate null reference bugs
- **Implicit usings** for cleaner code
- **Warnings as errors** – zero-tolerance for analyzer warnings
- **All analyzers enabled** (`AnalysisMode=All`) for maximum code quality
- **`InternalsVisibleTo`** – exposes internals to the test project without making types public
- **xUnit** for unit testing with Theory/InlineData for data-driven tests
- **`ArgumentException.ThrowIfNullOrWhiteSpace`** – idiomatic .NET 10 argument validation
