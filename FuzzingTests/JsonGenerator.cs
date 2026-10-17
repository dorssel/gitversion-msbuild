// SPDX-FileCopyrightText: 2026 Frans van Dorsselaer
//
// SPDX-License-Identifier: MIT

using System.Text.Json.Nodes;

namespace FuzzingTests;

static class JsonGenerator
{
    static readonly char[] AllowedKeyChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();

    public static Gen<JsonObject> GenerateExactlyTwoPairs()
    {
        // GitVersion keys are always strings of length 1 to 20, consisting of uppercase and lowercase letters.
        var keyGen = Gen.Choose(1, 20).SelectMany(
            length => Gen.ArrayOf(Gen.Elements(AllowedKeyChars), length).Select(chars => new string(chars)));

        // GitVersion values can be either strings or integers, so we create a generator that can produce both types.
        var valueGen = Gen.OneOf(
            ArbMap.Default.GeneratorFor<string>().Where(s => s is not null).Select(s => JsonValue.Create(s)),
            Gen.Choose(0, int.MaxValue).Select(i => JsonValue.Create(i)));

        var firstPairGen = Gen.Zip(keyGen, valueGen);

        // Chain the generation to enforce uniqueness on the second key
        return firstPairGen.SelectMany(firstPair =>
        {
            var key1 = firstPair.Item1;
            var val1 = firstPair.Item2;

            // CRITICAL: Key 2 must be different from Key 1 to avoid a duplicate key error
            var uniqueSecondKeyGen = keyGen.Where(key2 => key2 != key1);

            return Gen.Zip(uniqueSecondKeyGen, valueGen).Select(secondPair =>
            {
                var key2 = secondPair.Item1;
                var val2 = secondPair.Item2;

                return new JsonObject
                {
                    { key1, val1 },
                    { key2, val2 }
                };
            });
        });
    }
}
