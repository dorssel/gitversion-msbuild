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

This package is an alternative to the original [GitVersion.MsBuild](https://gitversion.net/docs/usage/msbuild), which
since version 6 no longer supports Visual Studio. This alternative *does* support Visual Studio.

## When

If you are using GitVersion.MsBuild version 6+ *and* Visual Studio, then you may want to use this package instead
of the original.

## What

Currently, this package is not (yet) a full replacement. I implemented only the features I required
for my own projects. However, it is really easy to extend it; I see no reason why this could not be a
full replacement for all use cases.

## What *NOT*

Just create an issue if you require one of the following features, which are currently *not* supported:

- VB, F# (currently only C# is supported)
- `UpdateAssemblyInfo` (this is not required for modern SDK style projects)

## How

Update the following reference:

```diff
-<PackageReference Include="GitVersion.MsBuild" PrivateAssets="all" />
+<PackageReference Include="Dorssel.GitVersion.MsBuild" PrivateAssets="all" />
```

Add the GitVersion CLI tool to your solution:

```powershell
dotnet tool install GitVersion.Tool
```

All done!
