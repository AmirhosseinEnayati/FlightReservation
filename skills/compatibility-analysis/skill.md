# Compatibility Analysis Skill

Purpose:
- Analyze compatibility risks between packages, framework versions, and ecosystems.

Input:
- reports/dependency-audit.json
- instruments/compatibility-checker.json

Actions:
- For .NET backend:
  - Check package major versions against targeted framework (e.g., ASP.NET Core, Microsoft.Extensions)
  - Validate Swashbuckle.AspNetCore vs ASP.NET Core runtime version compatibility
  - Check Newtonsoft.Json vs System.Text.Json usage and potential conflicts
  - Evaluate EF Core/related packages version matrix for breaking changes
  - Inspect Directory.Packages.props for version alignment across projects
  - Use project.assets.json to find transitive conflicting versions

- For frontend:
  - Validate React major version vs react-dom and other ecosystem packages
  - Verify TypeScript version compatibility with @types/* and build toolchain
  - Check peerDependencies for violations
  - Identify deprecated packages and suggest replacements with compatibility scoring

Analysis:
- Perform semantic version checks (semver) and map to risk levels.
- Use heuristics and known compatibility matrices shipped in instruments/compatibility-checker.json.

Outputs:
- reports/compatibility-analysis.json with entries per package:
  - currentVersion
  - recommendedVersion
  - compatibilityStatus (COMPATIBLE, WARNING, INCOMPATIBLE)
  - riskLevel (SAFE, REVIEW_REQUIRED, HIGH_RISK, BLOCKED)
  - notes
  - impact (dependent packages)

Notes:
- This skill produces the reasoning used in PR descriptions and to decide upgrade actions.