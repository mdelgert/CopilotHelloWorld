# CopilotHelloWorld

A .NET 10 C# Hello World console application built using best practices.

## Purpose of this repository

This repo is **not really about the Hello World app** — the app is intentionally trivial
(print a greeting, optionally repeated). Its real purpose is to be a small, safe playground for
learning the **end-to-end workflow of building software with GitHub and GitHub Copilot**:
repository setup, Copilot instructions, branches, pull requests, CI, code scanning, and dependency
automation. Everything in this README below the app documentation is a reusable checklist for
starting *any* new project the same way.

If you're used to doing all of this by hand (manual `git` commands, manually creating repos,
manually reviewing every diff) and want to know "what's the actual recommended process now,"
this document is written for you.

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

Prints the greeting 3 times by default. Pass a number as the first argument to repeat it a
different number of times:

```bash
dotnet run --project src/HelloWorld -- 5
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

See [Recommended workflow: starting a project from scratch](#recommended-workflow-starting-a-project-from-scratch)
below for the full process this repository follows, from creating the repo through merging
changes.

## Recommended workflow: starting a project from scratch

This is the process this repository itself followed, written out as a repeatable checklist.
It applies whether the "you" doing it is a human or a Copilot agent.

### 1. Create the repository

Pick one:

- **GitHub Copilot app / github.com** — create a new repository (empty, or from a template),
  then open it as a project in the Copilot app. The app clones it locally for you.
- **Manually** — `gh repo create <owner>/<name> --private --clone` (or use the GitHub web UI),
  then `git clone` it yourself.

Either way, the result is the same: one repository, one default branch (`main`).

### 2. Add repository-wide guardrails (do this once, early)

These are the files that make every future change — human or AI-generated — safer and faster,
because they encode the "how do I build/test/write code here" knowledge instead of making every
contributor rediscover it:

- **`.github/copilot-instructions.md`** — repo layout, exact build/test commands, and coding
  conventions, so Copilot (and new contributors) don't have to explore the codebase from
  scratch every time. See this repo's copy for a working example.
- **`.github/workflows/ci.yml`** — a GitHub Actions workflow that builds and tests on every push
  and pull request. Nothing should be considered "done" until this is green.
- **`.github/workflows/codeql.yml`** — CodeQL security scanning on push, PR, and a weekly
  schedule. If GitHub's own "default setup" for code scanning is also enabled on the repo, turn
  it off (`gh api -X PATCH repos/<owner>/<repo>/code-scanning/default-setup -f state=not-configured`) —
  a custom workflow and the default setup conflict and cause every scan to fail.
- **`.github/dependabot.yml`** — scheduled dependency and GitHub Actions version updates, so
  security patches show up as ready-to-review pull requests instead of silently going stale.
- **`README.md`** — what the project is, how to build/run/test it, and (for a learning repo like
  this one) the workflow itself.

### 3. Turn on repository safety settings

One-time settings, done in GitHub (Settings tab, or via `gh api`), not in code:

- **Branch protection on `main`** — require the CI check to pass before merging:
  ```bash
  gh api -X PUT repos/<owner>/<repo>/branches/main/protection \
    -f required_status_checks.strict=true \
    -f 'required_status_checks.contexts[]=Build and test' \
    -F enforce_admins=false \
    -F required_pull_request_reviews=null \
    -F restrictions=null
  ```
- **Secret scanning + push protection** (free on public repos):
  ```bash
  gh api -X PATCH repos/<owner>/<repo> \
    -F security_and_analysis[secret_scanning][status]=enabled \
    -F security_and_analysis[secret_scanning_push_protection][status]=enabled
  ```

### 4. One session (or branch) per unit of work

**The model to follow: 1 session = 1 branch = 1 worktree folder = 1 unit of work = 1 pull
request.** Do not reuse the same branch/session across multiple unrelated changes just because
its first change already merged — this is the single biggest source of confusion when learning
this workflow.

- **Starting something new and unrelated?** Start a **new session** (or, doing it manually,
  `git checkout -b my-change main` from an up-to-date `main`). This gives you a clean branch and
  folder with no leftover history from a previous, already-merged change.
- **Still iterating on the same not-yet-merged change?** Stay in the same session/branch and
  keep going — don't create a new one for every follow-up commit within one change.
- **A new change genuinely depends on another branch's unmerged work?** This is the one
  exception — explicitly base the new session/branch on that other branch instead of on `main`
  (a "stacked" change). Otherwise, always branch from the latest `main`.
- **Once a session's pull request merges, treat that session as finished.** Archive it (or just
  stop using it) rather than adding the next unrelated request to it. If you ask for something
  new in a session whose work already merged, expect to be offered a fresh session instead.

Never commit directly to `main`. For every change, however small:

1. **Create a branch** off `main`. In the Copilot app this happens automatically per session
   (each session gets its own branch and an isolated working folder — a "worktree" — so
   multiple sessions never collide). Manually: `git checkout -b my-change main`.
2. **Make the change and validate it locally** before pushing anything:
   ```bash
   dotnet restore CopilotHelloWorld.slnx
   dotnet build CopilotHelloWorld.slnx --configuration Release --no-restore
   dotnet test CopilotHelloWorld.slnx --configuration Release --no-build
   ```
3. **Commit** with a message that explains *why*, not just *what*.
4. **Push and open a pull request**, don't merge straight to `main`:
   ```bash
   git push -u origin my-change
   gh pr create --title "..." --body "..."
   ```
5. **Let CI run.** Build/test and CodeQL run automatically on the PR.
6. **Review the diff.** Read it, understand it, don't rubber-stamp AI-generated code.
7. **Merge once checks are green**:
   ```bash
   gh pr merge <number> --squash --delete-branch
   ```
8. **Archive the session (or delete the local branch) now that its work has merged**, and start
   the next request in a new one:
   ```bash
   git branch -d my-change
   ```

### 5. The fastest way to do this in practice

You do **not** need to type every `git`/`gh` command above by hand every time. Two faster paths,
in increasing order of automation:

- **`gh` CLI shortcuts** — if you're already comfortable with git but want less typing:
  `gh repo create`, `gh pr create`, `gh pr checks <number>`, `gh pr merge <number> --squash --delete-branch`
  replace most of the manual GitHub web UI clicking.
- **Ask a Copilot agent to do the whole loop** — this is what happened in this repo: describe
  the change in plain language ("add X", "fix the failing check", "merge PR #7") and the agent
  creates the branch/worktree, makes the change, runs the build/tests, pushes, opens the PR,
  waits for CI, and merges — the same steps above, just driven by conversation instead of
  hand-typed commands. This is the recommended default for day-to-day changes once the
  guardrails in steps 2–3 are in place, because the guardrails are what make it safe to let an
  agent drive: nothing merges to `main` without passing the same build, tests, and security scan
  a human change would have to pass.

### 6. Ongoing maintenance

- Review and merge Dependabot PRs as they arrive (weekly, per `dependabot.yml`) — don't let them
  pile up.
- Update `.github/copilot-instructions.md` whenever build commands, conventions, or project
  layout change, so future Copilot sessions stay accurate.
- Treat any red CI/CodeQL check as a signal to investigate before merging — but also learn to
  recognize infrastructure/config issues (like the default-setup conflict in step 2) that need a
  settings fix rather than a code change.
