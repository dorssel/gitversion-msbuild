// SPDX-FileCopyrightText: 2021 NServiceBus Ltd, GitTools and contributors.
// SPDX-FileCopyrightText: 2024 Frans van Dorsselaer
//
// SPDX-License-Identifier: MIT

using Microsoft.Build.Framework;

namespace Dorssel.GitVersion.MsBuild;

public abstract class GitVersionTaskBase
    : Microsoft.Build.Utilities.Task
{
    [Required]
    public string SolutionDirectory { get; set; } = null!;

    public string? VersionFile { get; set; }
}
