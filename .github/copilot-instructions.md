<!--
SPDX-FileCopyrightText: 2026 Frans van Dorsselaer

SPDX-License-Identifier: MIT
-->

# GitHub Copilot Review Instructions

## Code Review Scope & CI Assumptions

* **Assume CI handles build and toolchain verification:**
Do not flag SDK version upgrades, target framework updates, MSBuild property changes, linker/trimming settings, or
NuGet packaging configurations with reminders to verify that the project restores, builds, tests, trims, or packs in CI.

* **Treat CI checks as authoritative:**
Assume all compilation, unit testing, trimming validation, and package generation checks are enforced automatically by
GitHub Actions before merge.

* **Focus review on code and configuration defects:**
Limit feedback on project and build files (`.csproj`, `Directory.Build.props`, `global.json`, `.github/workflows/*`) to
actual syntax errors, invalid MSBuild conditions, security risks, or breaking configuration bugs.
