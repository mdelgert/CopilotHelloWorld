---
name: greeting-review
description: Guide for reviewing and extending the Greeter class in this repo (src/HelloWorld/Greeter.cs). Use this when asked to add a new greeting, review greeting logic, or check greeting-related code for style/analyzer compliance.
license: MIT
---

# Greeting Review Skill

This skill helps you work with the `Greeter` class in `src/HelloWorld/Greeter.cs` and its
tests in `tests/HelloWorld.Tests/GreeterTests.cs`, following this repo's conventions.

## When to use this skill

- Adding a new greeting method or overload to `Greeter`.
- Reviewing existing greeting logic for correctness or style.
- Checking that greeting-related changes satisfy the repo's analyzer rules.

## Steps

1. Read `src/HelloWorld/Greeter.cs` and `tests/HelloWorld.Tests/GreeterTests.cs` first to
   understand current behavior and test coverage.
2. Keep the `Greeter` type `internal sealed` — do not make it `public`. Tests already see it
   via `InternalsVisibleTo`.
3. Validate any new string parameters with `ArgumentException.ThrowIfNullOrWhiteSpace` (not
   hand-written `if`/`throw`).
4. Add XML doc comments to any new public/internal member, including `<exception>` tags for
   thrown exceptions.
5. Add matching `[Theory]`/`[InlineData]` or `[Fact]` tests for every new behavior, including
   failure cases (e.g., null/empty/whitespace input).
6. Run the full validation sequence before proposing the change:
   ```bash
   dotnet restore CopilotHelloWorld.slnx
   dotnet build CopilotHelloWorld.slnx --configuration Release --no-restore
   dotnet test CopilotHelloWorld.slnx --configuration Release --no-build
   ```
7. Fix any analyzer warnings — `TreatWarningsAsErrors` is on, so warnings fail the build.

## Notes

- This is a sample/test skill created to demonstrate the skills mechanism. Feel free to
  delete or repurpose it.
