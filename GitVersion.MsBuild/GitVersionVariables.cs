// SPDX-FileCopyrightText: 2024 Frans van Dorsselaer
//
// SPDX-License-Identifier: MIT

using System.Collections.ObjectModel;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Dorssel.GitVersion.MsBuild;

static class GitVersionVariables
{
    public static ReadOnlyDictionary<string, string> FromJson(string json)
    {
        var serializer = new DataContractJsonSerializer(typeof(Dictionary<string, string>),
            new DataContractJsonSerializerSettings()
            {
                UseSimpleDictionaryFormat = true
            });

        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
        var result = (Dictionary<string, string>)serializer.ReadObject(stream);
        return new(result);
    }
}
