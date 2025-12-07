<!--
SPDX-FileCopyrightText: 2024 Frans van Dorsselaer

SPDX-License-Identifier: MIT
-->

# GitVersion.MsBuild (netstandard2.0)

[![Build](https://github.com/dorssel/gitversion-msbuild/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/dorssel/gitversion-msbuild/actions?query=workflow%3ABuild+branch%3Amain)
[![CodeQL](https://github.com/dorssel/gitversion-msbuild/actions/workflows/codeql.yml/badge.svg?branch=main)](https://github.com/dorssel/gitversion-msbuild/actions?query=workflow%3ACodeQL+branch%3Amain)
[![Lint](https://github.com/dorssel/gitversion-msbuild/actions/workflows/lint.yml/badge.svg?branch=main)](https://github.com/dorssel/gitversion-msbuild/actions?query=workflow%3ALint+branch%3Amain)
[![REUSE status](https://api.reuse.software/badge/github.com/dorssel/gitversion-msbuild)](https://api.reuse.software/info/github.com/dorssel/gitversion-msbuild)
[![Codecov](https://codecov.io/gh/dorssel/gitversion-msbuild/branch/main/graph/badge.svg?token=gn5x2PehaL)](https://codecov.io/gh/dorssel/gitversion-msbuild)
[![NuGet](https://img.shields.io/nuget/v/Dorssel.GitVersion.MsBuild?logo=nuget)](https://www.nuget.org/packages/Dorssel.GitVersion.MsBuild)

## Why

This package is an addition to the original [GitVersion.MsBuild](https://gitversion.net/docs/usage/msbuild), which
does not support building WiX projects that use GitVersion.MsBuild from within Visual Studio 2026.

For older Visual Studio versions, see the README for this project,
[version 1.1.1](https://github.com/dorssel/gitversion-msbuild/tree/v1.1.1?tab=readme-ov-file#gitversionmsbuild-netstandard20).

## When

If you are building WiX projects that use GitVersion.MsBuild from within Visual Studio 2026, you need this package.
If not, then you do not need this package at all.

## How

Add the following reference in your WiX project:

```diff
<PackageReference Include="GitVersion.MsBuild" PrivateAssets="all" />
+<PackageReference Include="Dorssel.GitVersion.MsBuild" PrivateAssets="all" Version="2.*" />
```

All done!
