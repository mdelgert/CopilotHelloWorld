# CopilotHelloWorld

A .NET 10 C# Hello World console application built using best practices.

## Project Structure

```
CopilotHelloWorld.slnx
├── .github/
│   ├── copilot-instructions.md  # Repository instructions for GitHub Copilot
│   ├── dependabot.yml           # Weekly NuGet + Actions updates
│   └── workflows/               # CI (build/test) and CodeQL analysis
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
- **Continuous integration** – every push and pull request is built and tested
- **CodeQL scanning** and **Dependabot** – automated security and dependency checks
- **Copilot repository instructions** – `.github/copilot-instructions.md` tells GitHub Copilot
  how to build, test, and write code that fits this project

## Working with GitHub Copilot

This repository includes [repository custom instructions](https://docs.github.com/en/copilot/how-tos/copilot-on-github/customize-copilot/add-custom-instructions/add-repository-instructions)
in `.github/copilot-instructions.md`. Copilot reads them automatically, so suggestions follow
the project's conventions without being re-explained each time. Update that file whenever the
build commands, layout, or coding conventions change.

Generated code still needs review: read it before accepting it, and rely on `dotnet test` and
the CI workflow to catch what review misses.
