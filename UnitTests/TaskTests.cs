// SPDX-FileCopyrightText: 2024 Frans van Dorsselaer
//
// SPDX-License-Identifier: MIT

using System.Reflection;

namespace UnitTests;

[TestClass]
sealed class TaskTests
{
    public required TestContext TestContext { get; set; }

    static string GetVersionFile()
    {
        for (var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            directory is not null; directory = Path.GetDirectoryName(directory))
        {
            var file = Path.Combine(directory, "obj", "gitversion.json");
            if (File.Exists(file))
            {
                return file;
            }
        }
        throw new FileNotFoundException("gitversion.json");
    }

    [TestMethod]
    public void GenerateGitVersionInformation_WithIntermediateOutputPath()
    {
        var task = new Dorssel.GitVersion.MsBuild.GenerateGitVersionInformation
        {
            VersionFile = GetVersionFile(),
            IntermediateOutputPath = TestContext.TestRunDirectory!
        };
        var result = task.Execute();
        Assert.IsTrue(result);
    }
}
