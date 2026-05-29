# Generate PR Description Prompt

Template variables:
- summary
- deprecatedPackages
- compatibilityAnalysis (json)
- validationResults
- agentReasoning

Prompt:

Write a comprehensive PR description with the following sections:

# Summary

{summary}

## Deprecated packages found

{deprecatedPackages}

## Compatibility analysis

{compatibilityAnalysis}

## Validation results

{validationResults}

## Agent reasoning

{agentReasoning}

Include for each package: current version, recommended version, compatibility status, risk level, breaking change notes, impacted dependent packages.

End with guidance for maintainers on how to review and merge safely.