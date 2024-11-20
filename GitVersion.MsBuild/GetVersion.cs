// SPDX-FileCopyrightText: 2021 NServiceBus Ltd, GitTools and contributors.
// SPDX-FileCopyrightText: 2024 Frans van Dorsselaer
//
// SPDX-License-Identifier: MIT

using Microsoft.Build.Framework;

namespace Dorssel.GitVersion.MsBuild;

public class GetVersion
    : GitVersionTaskBase
{
    [Output]
    public string Major { get; set; } = string.Empty;

    [Output]
    public string Minor { get; set; } = string.Empty;

    [Output]
    public string Patch { get; set; } = string.Empty;

    [Output]
    public string PreReleaseTag { get; set; } = string.Empty;

    [Output]
    public string PreReleaseTagWithDash { get; set; } = string.Empty;

    [Output]
    public string PreReleaseLabel { get; set; } = string.Empty;

    [Output]
    public string PreReleaseLabelWithDash { get; set; } = string.Empty;

    [Output]
    public string PreReleaseNumber { get; set; } = string.Empty;

    [Output]
    public string WeightedPreReleaseNumber { get; set; } = string.Empty;

    [Output]
    public string BuildMetaData { get; set; } = string.Empty;

    [Output]
    public string FullBuildMetaData { get; set; } = string.Empty;

    [Output]
    public string MajorMinorPatch { get; set; } = string.Empty;

    [Output]
    public string SemVer { get; set; } = string.Empty;

    [Output]
    public string AssemblySemVer { get; set; } = string.Empty;

    [Output]
    public string AssemblySemFileVer { get; set; } = string.Empty;

    [Output]
    public string FullSemVer { get; set; } = string.Empty;

    [Output]
    public string InformationalVersion { get; set; } = string.Empty;

    [Output]
    public string BranchName { get; set; } = string.Empty;

    [Output]
    public string EscapedBranchName { get; set; } = string.Empty;

    [Output]
    public string Sha { get; set; } = string.Empty;

    [Output]
    public string ShortSha { get; set; } = string.Empty;

    [Output]
    public string CommitDate { get; set; } = string.Empty;

    [Output]
    public string VersionSourceSha { get; set; } = string.Empty;

    [Output]
    public string CommitsSinceVersionSource { get; set; } = string.Empty;

    [Output]
    public string UncommittedChanges { get; set; } = string.Empty;

    public override bool Execute()
    {
        foreach (var keyValue in GitVersionVariables.FromFile(VersionFile!))
        {
            GetType().GetProperty(keyValue.Key).SetValue(this, keyValue.Value);
        }

        return !Log.HasLoggedErrors;
    }
}
