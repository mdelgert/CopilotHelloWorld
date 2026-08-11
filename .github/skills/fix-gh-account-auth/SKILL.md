---
name: fix-gh-account-auth
description: >-
  Guide for fixing GitHub CLI (gh) commands that fail because the wrong GitHub account is
  active, including Enterprise Managed User (EMU) token conflicts. Use this when a gh command
  fails with an authorization/permission error (e.g. "Unauthorized: As an Enterprise Managed
  User, you cannot access this content", "Resource not accessible", or 403/404 errors on a
  repo you know you have access to), or before running gh pr create / gh pr merge / gh api
  against a repo owned by a personal account while a work/EMU account may also be logged in.
license: MIT
---

# Fix gh Account Auth Skill

`gh` CLI operations can silently target the wrong GitHub account when multiple accounts are
authenticated on the machine (e.g. a personal account and a separate work/Enterprise Managed
User account), or when a `GH_TOKEN` environment variable is pinned to one of them. This shows
up as authorization errors on a repo you actually have access to under a different account.

## When to use this skill

- A `gh` command fails with an authorization/permission error even though you believe you
  have access to the repo (e.g. EMU "Unauthorized" errors, unexpected 403/404s).
- Before running `gh pr create`, `gh pr merge`, `gh api`, or similar commands, as a
  preventive check when more than one GitHub account may be configured locally.

## Steps

1. Check which accounts `gh` knows about and which is active:
   ```powershell
   gh auth status
   ```
2. Identify the account that actually owns/has access to the target repository. If the
   active account is the wrong one, and a `GH_TOKEN` environment variable is set, clear it
   for the command — PowerShell resets env vars per process, so this must be done in the
   *same* command as the `gh` call:
   ```powershell
   Remove-Item Env:\GH_TOKEN -ErrorAction SilentlyContinue; gh auth status
   ```
   This lets `gh` fall back to the correct keyring-stored credential instead of the
   environment-pinned token.
3. If clearing `GH_TOKEN` doesn't fix it, explicitly switch accounts:
   ```powershell
   gh auth switch --user <correct-account>
   ```
4. Re-run the original `gh` command (PR create, merge, api call, etc.) in the same
   PowerShell invocation, right after the fix, e.g.:
   ```powershell
   Remove-Item Env:\GH_TOKEN -ErrorAction SilentlyContinue; gh pr create --title "..." --body "..." --base main --head <branch>
   ```
5. Confirm success by checking `gh auth status` shows the correct account as active before
   relying on the result of the `gh` command.

## Notes

- This only affects `gh` CLI calls in the current shell session; each new PowerShell
  invocation starts fresh, so the environment fix must be reapplied for every subsequent
  `gh` command that needs the correct account.
- For a permanent fix instead of clearing it each time, unset the conflicting env var at the
  user/machine environment variable level outside of this session.
- Never hardcode specific account usernames/tokens into this skill or commit them to the
  repo — keep it generic so it works for anyone using this repo.
