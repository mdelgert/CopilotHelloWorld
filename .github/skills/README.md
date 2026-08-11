# Copilot Skills

Skills are reusable instruction packages that GitHub Copilot (CLI/agent) can load on demand
to guide how it performs a specific kind of task. Unlike tools (direct function calls), a
skill is documentation/procedure that shapes *how* the agent uses its tools for a domain.

## Where skills live

- **Project skills** (shared with the repo, checked into git): `.github/skills/<skill-name>/SKILL.md`
- **Personal skills** (available across all your projects, not committed): `~/.copilot/skills/<skill-name>/SKILL.md`
  (on Windows: `%USERPROFILE%\.copilot\skills\<skill-name>\SKILL.md`)

Each skill gets its own folder named after the skill. You can include extra files (scripts,
examples, reference docs) alongside `SKILL.md` in that folder.

## How to create a skill

1. Create a folder: `.github/skills/<skill-name>/`
   - Use a lowercase, hyphenated name that matches the `name` field below.
2. Add a `SKILL.md` file with YAML frontmatter followed by Markdown instructions:

   ```markdown
   ---
   name: my-custom-skill
   description: Guide for <what it does>. Use this when asked to <trigger phrases>.
   license: MIT
   ---

   # My Custom Skill

   1. Step one...
   2. Step two...
   ```

3. Write a clear, specific `description` — it's how Copilot decides when to invoke the
   skill, so include both what it does and when to use it.
4. Restart or reload the Copilot session so it picks up the new/changed skill.

## Using a skill

Copilot automatically checks available skills against your request and invokes a matching
one before responding. You can also explicitly reference a skill by name in your prompt if
you want to force its use.

## Examples in this repo

- `.github/skills/greeting-review/SKILL.md` guides Copilot through adding/reviewing greeting
  logic in `Greeter.cs` following our conventions (internal sealed types, modern guard
  clauses, XML docs, xUnit tests, and the restore/build/test validation sequence). Try it by
  asking Copilot to "add a new greeting method to Greeter" and observe it follow the skill's
  steps.
- `.github/skills/ship-and-merge/SKILL.md` fully automates validate → commit → push →
  open PR → merge into `main`, with **no manual approval pause**. Triggered by prompts like
  "ship this" or "ship and merge". This is intentionally scoped to low-stakes/learning repos
  with no branch protection on `main` — do not copy it into a repo where `main` is protected
  or real users depend on it.
