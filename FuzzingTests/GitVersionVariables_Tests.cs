// SPDX-FileCopyrightText: 2026 Frans van Dorsselaer
//
// SPDX-License-Identifier: MIT

using System.Text.Json.Nodes;

namespace FuzzingTests;

[TestClass]
sealed class GitVersionVariables_Tests
{
    [TestMethod]
    public void JsonIsParsedCorrectly()
    {
        var jsonGenerator = JsonGenerator.GenerateExactlyTwoPairs();

        Prop.ForAll(Arb.From(jsonGenerator), (JsonObject json) =>
        {
            var result = GitVersionVariables.FromJson(json.ToJsonString());
            return result.Count == 2 && json.All(pair => result.TryGetValue(pair.Key, out var value) && value == pair.Value!.ToString());
        }).QuickCheckThrowOnFailure();
    }
}
