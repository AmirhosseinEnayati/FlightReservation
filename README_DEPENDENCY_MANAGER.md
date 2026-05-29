Dependency Manager Agent for FlightReservation

This directory contains the GitHub Copilot agentic scaffold for automated dependency maintenance.

Structure:
- agents/: agent definitions
- skills/: skill descriptions used by the agent
- workflows/: GitHub workflow orchestrations
- prompts/: prompts used for PR descriptions and decisions
- instruments/: JSON rules for scanning and compatibility
- hooks/: pre and post upgrade procedures

Deploy:
- The scheduled workflow .github/workflows/dependency-managing.yml runs weekly and creates PRs for safe upgrades.
- Customize instruments/*.json to tune compatibility heuristics and branch naming.

Usage:
- Maintain the files in this scaffold as living documents describing behavior implemented by the agent runner.
