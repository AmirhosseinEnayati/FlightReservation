# Upgrade Execution Skill

Purpose:
- Apply safe dependency upgrades automatically, create branches, commit changes, and push PRs.

Input:
- reports/compatibility-analysis.json
- decision rules (prompts/upgrade-decision.md)

Actions:
- For SAFE items:
  - For .NET: update Directory.Packages.props or project references, run `dotnet restore` and `dotnet build`
  - For npm: run `npm install <pkg>@<version>` and update package.json and lockfiles
  - Commit changes on a new branch named `deps/auto/<scope>/<package>-<version>`
  - Run validation skill
  - If validation passes, push and open a PR with generated description

- For REVIEW_REQUIRED:
  - Create draft PR with detailed analysis and leave action for maintainers

- For HIGH_RISK or BLOCKED:
  - Do not modify repository; create issue with remediation suggestions and include compatibility analysis report

Outputs:
- Git branches and PRs
- reports/upgrade-actions.json describing what was applied

Notes:
- The skill respects repository CI and will not merge automatically; it creates PRs. Auto-merge can be enabled by maintainers after review.