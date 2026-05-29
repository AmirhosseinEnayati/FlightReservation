# Upgrade Decision Prompt

Context:
- Package metadata
- Compatibility analysis
- Tests and build results

Decision rules:
- If riskLevel == SAFE and validation passes -> apply upgrade and create normal PR
- If riskLevel == REVIEW_REQUIRED -> create draft PR with full analysis
- If riskLevel == HIGH_RISK -> create draft PR and label 'high-risk'
- If riskLevel == BLOCKED -> do not modify, create an issue with remediation

Produce a structured JSON decision document:
{
  "package": "",
  "currentVersion": "",
  "recommendedVersion": "",
  "decision": "apply|draft-pr|issue|noop",
  "reason": "",
  "commands": ["list of shell commands to run to apply or test the upgrade"]
}

Include commit message and branch naming suggestion.