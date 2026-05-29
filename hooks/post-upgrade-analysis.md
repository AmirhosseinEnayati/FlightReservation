# Post-Upgrade Analysis Hook

After an upgrade attempt, the agent must:

1. Run full validation (build/test) and capture logs
2. Perform runtime smoke checks if applicable
3. Analyze test failures to determine if failures are caused by the upgrade (heuristic: new stack traces referencing upgraded assemblies)
4. If failures are unrelated, allow PR creation but annotate with findings
5. If failures are likely caused by the upgrade, revert changes and open an issue with detailed analysis

The hook produces reports/validation.json and artifacts with logs.