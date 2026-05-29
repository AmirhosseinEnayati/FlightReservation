# Compatibility Risk Analysis Prompt

Input: reports/compatibility-analysis.json

Produce a human-readable compatibility analysis listing each package and a concise explanation of:
- Why it's safe to upgrade or not
- Which runtime/framework constraints are relevant
- Which dependent packages may be impacted
- Suggested replacement if deprecated
- Suggested testing checklist

Output as markdown with headings by package name.
