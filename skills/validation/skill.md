# Validation Skill

Purpose:
- Run build and test validation for backend and frontend after upgrades.

Input:
- repository root
- report of applied changes

Actions:
- Backend (.NET):
  - dotnet restore
  - dotnet build --configuration Release
  - dotnet test --no-build --logger "trx" --results-directory test-results

- Frontend (Node):
  - npm install
  - npm run build (if present)
  - npm test (if present)

- Optional additional checks:
  - run ESLint, TypeScript compiler checks
  - run static analyzers (dotnet format, roslyn analyzers)

Outputs:
- reports/validation.json with build and test outcomes, logs and artifacts paths
- If validation fails, rollback the changes and annotate PR with failure logs

Notes:
- Validation step is mandatory before pushing a non-draft PR. Draft PRs for high risk may skip full validation but include guidance.