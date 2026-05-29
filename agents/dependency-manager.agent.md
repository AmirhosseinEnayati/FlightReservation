# dependency-manager-agent

Name: dependency-manager-agent

Purpose:
- Autonomous dependency maintenance and compatibility intelligence across backend (.NET) and frontend (Node/npm) components in the FlightReservation monorepo.

Responsibilities:
- Weekly scans for outdated, deprecated, incompatible and transitive dependency conflicts.
- Classify findings into SAFE, REVIEW_REQUIRED, HIGH_RISK, BLOCKED.
- Apply safe upgrades automatically and create pull requests for applied changes.
- Generate draft PRs with detailed compatibility analysis for major/uncertain upgrades.
- Open issues when upgrades are blocked by conflicts and include remediation analysis.
- Run backend and frontend validation, run tests, and include validation results in PRs.

Primary interfaces:
- Instruments: JSON configurations that instruct scanning and compatibility checks.
- Skills: modular responsibilities (dependency-audit, compatibility-analysis, upgrade-execution, validation).
- Prompts: templates for PR descriptions and analysis content.
- Hooks: pre- and post-upgrade human review instructions.

Execution model:
- The agent is executed by a scheduled GitHub Actions workflow (.github/workflows/dependency-managing.yml) or can be triggered manually.
- It uses the repository GitHub token to create branches, push changes, and open PRs.
- Decision engine uses semantic versioning rules, dependency graph inspection and instrument rules to determine safe automated upgrades and items requiring human review.

Outputs:
- PRs with a standardized Summary, Compatibility analysis, Validation results, and Agent reasoning.
- Machine-readable artifacts: reports/*.json and artifacts uploaded to the workflow run.

Security & safety:
- Major upgrades or high-risk changes never merged automatically; they create draft PRs with full analysis.
- If the upgrade attempt fails build/tests, it is reverted and a draft PR + issue are created for human action.

Contact: GitHub Actions runner + GitHub API via actions/github-script and gh (if present).