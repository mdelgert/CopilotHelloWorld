---
name: ship-and-merge
description: Guide for shipping the current change end-to-end in this learning repo -- validate, commit, push, open a PR, and auto-merge it into main without waiting for manual approval. Use this when asked to "ship this", "ship and merge", or "auto merge this change". Only intended for repos with no branch protection (e.g. learning/sandbox repos), not production repos.
license: MIT
---

# Ship and Merge Skill

This skill fully automates getting the current change into `main`, including the merge
step, with no manual approval pause. **Only use this in low-stakes/learning repos without
branch protection** (like this CopilotHelloWorld repo). Do not reuse it in a repo where
`main` has protections, required reviewers, or real users depending on it.

## When to use this skill

- The user says "ship this", "ship and merge", or "auto merge this change".
- The repo is confirmed to have no branch protection on `main`.

## Steps

1. Run the repo's validation sequence and confirm it passes before doing anything else:
```bash
  dotnet restore CopilotHelloWorld.slnx
   dotnet build CopilotHelloWorld.slnx --configuration Release --no-restore
   dotnet test CopilotHelloWorld.slnx --configuration Release --no-build
```
   Stop and report failures instead of proceeding if any step fails.
2. Stage and commit all current changes with a clear, descriptive commit message.
3. Push the current branch to the remote.
4. Open a pull request against `main` using the `create_pull_request` tool.
5. Merge the pull request immediately using the GitHub CLI, no manual wait:
```
   gh pr merge <pr-number> --merge --delete-branch
```
   (Use `--squash` instead of `--merge` if the user prefers a squashed history.)
6. Confirm the merge succeeded and report the final commit/PR link back to the user.

## Guardrails

- Before merging, double check `gh api repos/{owner}/{repo}/branches/main/protection` (or
  equivalent) does not show required reviews/status checks. If it does, stop and fall back
  to just opening the PR for manual review instead of merging.
- Never use this skill on a repo you haven't confirmed is unprotected/low-stakes.
- Still report what changed and link the merged PR so the user has a record, even though no
  manual approval gate was used.
