// SPDX-FileCopyrightText: 2024 Frans van Dorsselaer
//
// SPDX-License-Identifier: MIT

using Dorssel.GitVersion.MsBuild;
using Microsoft.Build.Framework;
using Moq;

namespace UnitTests;

[TestClass]
sealed class TaskTests
{
    public required TestContext TestContext { get; set; }

    static string GetTestData(string path1, params string[] pathN)
    {
        var file = Path.Combine([AppContext.BaseDirectory, path1, .. pathN]);
        return File.Exists(file) ? file : throw new FileNotFoundException(((IEnumerable<string>)[path1, .. pathN]).Last());
    }

    [TestMethod]
    public void GetVersion_Normal()
    {
        var buildEngine = new Mock<IBuildEngine>();
        var task = new GetVersion
        {
            BuildEngine = buildEngine.Object,
            VersionFile = GetTestData("gitversion.json"),
            SolutionDirectory = TestContext.TestRunDirectory!
        };
        var result = task.Execute();
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void GetVersion_Future()
    {
        var buildEngine = new Mock<IBuildEngine>();
        var task = new GetVersion
        {
            BuildEngine = buildEngine.Object,
            VersionFile = GetTestData("data", "future-gitversion.json"),
            SolutionDirectory = TestContext.TestRunDirectory!
        };
        var result = task.Execute();
        Assert.IsTrue(result);
    }
}
