# CopilotHelloWorld — repository instructions

## What this repository is

A small .NET 10 C# console application demonstrating project structure and code-quality
practices. Two projects only, roughly 200 lines of code total:

- `src/HelloWorld/` — console app (`Program.cs` entry point, `Greeter.cs` greeting logic)
- `tests/HelloWorld.Tests/` — xUnit test project (`GreeterTests.cs`)
- `CopilotHelloWorld.slnx` — solution file in the newer XML `.slnx` format (not `.sln`)

## Build and validate

Requires the **.NET 10 SDK** (developed against 10.0.301). Always run these from the
repository root, in this order:

```bash
dotnet restore CopilotHelloWorld.slnx
dotnet build CopilotHelloWorld.slnx --configuration Release --no-restore
dotnet test CopilotHelloWorld.slnx --configuration Release --no-build
```

To run the app:

```bash
dotnet run --project src/HelloWorld
```

`dotnet build` and `dotnet test` also work without arguments; they discover the `.slnx`
automatically. A full clean build plus test run takes well under a minute.

**Always run `dotnet test` before proposing a change.** There is no lint step separate from
the build — analyzers run as part of compilation.

## Conventions that changes must follow

- `TreatWarningsAsErrors` is on and `AnalysisMode` is `All`, so **any analyzer warning breaks
  the build**. Fix warnings rather than suppressing them; if suppression is truly needed, use
  a targeted `#pragma` or attribute with a justification comment.
- `Nullable` and `ImplicitUsings` are enabled in both projects. Do not add `using` directives
  that implicit usings already cover.
- Application types are `internal sealed` by default. The test project sees them through
  `InternalsVisibleTo` declared in `src/HelloWorld/HelloWorld.csproj` — keep types internal
  instead of widening them to `public` for testability.
- Public and internal members carry XML doc comments, including `<exception>` tags where the
  member throws. Match that style.
- Validate arguments with the modern guard helpers (`ArgumentException.ThrowIfNullOrWhiteSpace`,
  `ArgumentNullException.ThrowIfNull`) rather than hand-written `if`/`throw`.
- Tests use xUnit with `[Theory]`/`[InlineData]` for data-driven cases and `[Fact]` for
  single cases. `Xunit` is a global using declared in the test csproj.

## When adding code

- New production code goes under `src/HelloWorld/`; new tests mirror it under
  `tests/HelloWorld.Tests/`. Every new behavior needs a test, including its failure cases.
- New projects must be registered in `CopilotHelloWorld.slnx` under the matching `src` or
  `tests` folder node.
- Keep package versions pinned explicitly, as the existing `PackageReference` entries are.
- Never commit secrets or local environment files; `.env`, `bin/`, `obj/`, and `.vs/` are
  already ignored.

## CI

`.github/workflows/ci.yml` builds and tests on every push and pull request. Changes must pass
it, so reproduce failures locally with the commands above before pushing.
