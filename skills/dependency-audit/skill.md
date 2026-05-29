# Dependency Audit Skill

Purpose:
- Perform initial discovery and enumeration of direct and transitive dependencies for backend and frontend projects.

Input:
- Repository root
- Paths to scan (defaults: all .csproj, Directory.Packages.props, package.json, package-lock.json, yarn.lock)

Actions:
- For backend (.NET):
  - Locate projects and solution files
  - Run `dotnet list <project> package --outdated --highest-minor` to detect outdated packages
  - Parse Directory.Packages.props for central package versions
  - Use `dotnet restore` and `nuget` tools to produce the dependency graph (nuget assets file)
  - Record transitive dependency graph from obj/project.assets.json

- For frontend (npm):
  - Run `npm outdated --json` to fetch outdated packages
  - Read `package.json` and lock files to compute resolved versions
  - Run `npm ls --json` to capture the dependency tree and detect peer dependency warnings

Outputs:
- reports/dependency-audit.json containing:
  - directDependencies: []
  - transitiveDependencies: []
  - outdated: []
  - deprecated: [] (lookup via npm deprecations and NuGet deprecation API)
  - graphs: { backend, frontend }

Notes:
- This skill emits structured JSON used by compatibility-analysis skill.