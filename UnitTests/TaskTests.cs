// SPDX-FileCopyrightText: 2024 Frans van Dorsselaer
//
// SPDX-License-Identifier: MIT

using System.Reflection;
using Dorssel.GitVersion.MsBuild;
using Microsoft.Build.Framework;
using Moq;

namespace UnitTests;

[TestClass]
sealed class TaskTests
{
    public required TestContext TestContext { get; set; }

    static string GetVersionFile()
    {
        var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        var file = Path.Combine(directory, "gitversion.json");
        return File.Exists(file) ? file : throw new FileNotFoundException("gitversion.json");
    }

    [TestMethod]
    public void GetVersion_Normal()
    {
        var buildEngine = new Mock<IBuildEngine>();
        var task = new GetVersion
        {
            BuildEngine = buildEngine.Object,
            VersionFile = GetVersionFile(),
            SolutionDirectory = TestContext.TestRunDirectory!
        };
        var result = task.Execute();
        Assert.IsTrue(result);
    }
}
