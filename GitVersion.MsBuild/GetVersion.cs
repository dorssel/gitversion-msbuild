// SPDX-FileCopyrightText: 2021 NServiceBus Ltd, GitTools and contributors.
// SPDX-FileCopyrightText: 2024 Frans van Dorsselaer
//
// SPDX-License-Identifier: MIT

using Microsoft.Build.Framework;

namespace Dorssel.GitVersion.MsBuild;

public class GetVersion : GitVersionTaskBase
{
    [Output]
    public string AssemblySemFileVer { get; set; } = string.Empty;

    [Output]
    public string AssemblySemVer { get; set; } = string.Empty;

    [Output]
    public string BranchName { get; set; } = string.Empty;

    [Output]
    public string BuildMetaData { get; set; } = string.Empty;

    [Output]
    public string CommitCountSourceDistance { get; set; } = string.Empty;

    [Output]
    public string CommitCountSourceSha { get; set; } = string.Empty;

    [Output]
    public string CommitDate { get; set; } = string.Empty;

    [Output]
    [Obsolete("CommitsSinceVersionSource has been deprecated in GitVersion v6, and was removed from v7. Use VersionSourceDistance instead.")]
    public string CommitsSinceVersionSource { get; set; } = string.Empty;

    [Output]
    public string CustomVersion { get; set; } = string.Empty;

    [Output]
    public string EscapedBranchName { get; set; } = string.Empty;

    [Output]
    public string FullBuildMetaData { get; set; } = string.Empty;

    [Output]
    public string FullSemVer { get; set; } = string.Empty;

    [Output]
    public string InformationalVersion { get; set; } = string.Empty;

    [Output]
    public string Major { get; set; } = string.Empty;

    [Output]
    public string MajorMinorPatch { get; set; } = string.Empty;

    [Output]
    public string Minor { get; set; } = string.Empty;

    [Output]
    public string Patch { get; set; } = string.Empty;

    [Output]
    public string PreReleaseLabel { get; set; } = string.Empty;

    [Output]
    public string PreReleaseLabelName { get; set; } = string.Empty;

    [Output]
    public string PreReleaseLabelWithDash { get; set; } = string.Empty;

    [Output]
    public string PreReleaseLabelNameWithDash { get; set; } = string.Empty;

    [Output]
    public string PreReleaseNumber { get; set; } = string.Empty;

    [Output]
    [Obsolete("PreReleaseTag has been renamed to PreReleaseLabel in GitVersion v7, and the old PreReleaseLabel has been renamed to PreReleaseLabelName.")]
    public string PreReleaseTag { get; set; } = string.Empty;

    [Output]
    [Obsolete("PreReleaseTagWithDash has been renamed to PreReleaseLabelWithDash in GitVersion v7, and the old PreReleaseLabelWithDash has been renamed to PreReleaseLabelNameWithDash.")]
    public string PreReleaseTagWithDash { get; set; } = string.Empty;

    [Output]
    public string SemVer { get; set; } = string.Empty;

    [Output]
    public string SemVerSourceIncrement { get; set; } = string.Empty;

    [Output]
    public string SemVerSourceSemVer { get; set; } = string.Empty;

    [Output]
    public string SemVerSourceSha { get; set; } = string.Empty;

    [Output]
    public string Sha { get; set; } = string.Empty;

    [Output]
    public string ShortSha { get; set; } = string.Empty;

    [Output]
    public string UncommittedChanges { get; set; } = string.Empty;

    [Output]
    public string VersionSourceDistance { get; set; } = string.Empty;

    [Output]
    public string VersionSourceIncrement { get; set; } = string.Empty;

    [Output]
    public string VersionSourceSemVer { get; set; } = string.Empty;

    [Output]
    public string VersionSourceSha { get; set; } = string.Empty;

    [Output]
    public string WeightedPreReleaseNumber { get; set; } = string.Empty;

    public override bool Execute()
    {
        foreach (var keyValue in GitVersionVariables.FromJson(File.ReadAllText(VersionFile)))
        {
            var property = GetType().GetProperty(keyValue.Key);
            if (property is null)
            {
                Log.LogMessage($"GitVersion.MsBuild exposes '{keyValue.Key}', which is not (yet) mapped by Dorssel.GitVersion.MsBuild.");
            }
            else
            {
                property.SetValue(this, keyValue.Value);
            }
        }

        return !Log.HasLoggedErrors;
    }
}
