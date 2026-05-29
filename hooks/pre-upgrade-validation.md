# Pre-Upgrade Validation Hook

Before applying upgrades automatically, the agent must:

1. Ensure working tree is clean
2. Create a new branch from default branch
3. Run targeted unit tests related to packages if known
4. Run `dotnet restore` and `npm install --package-lock-only` to ensure lockfiles are updated
5. Run compatibility checks for the specific package (from instruments/compatibility-checker.json)

If any step fails, abort and classify the change as REVIEW_REQUIRED or BLOCKED.