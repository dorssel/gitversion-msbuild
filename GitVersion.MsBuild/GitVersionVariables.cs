// SPDX-FileCopyrightText: 2024 Frans van Dorsselaer
//
// SPDX-License-Identifier: MIT

using System.Collections.ObjectModel;

namespace Dorssel.GitVersion.MsBuild;

static class GitVersionVariables
{
    public static ReadOnlyDictionary<string, string> FromFile(string versionFile)
    {
        var dictionary = new Dictionary<string, string>();

        foreach (var line in File.ReadAllLines(versionFile))
        {
            var keyValue = line.Split(':');
            if (keyValue.Length != 2)
            {
                // opening or closing brace
                continue;
            }
            dictionary.Add(keyValue[0].Trim(' ', '"'), keyValue[1].Trim(' ', '"', ','));
        }

        return new(dictionary);
    }
}
