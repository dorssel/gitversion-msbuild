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

    [TestMethod]
    public void GenerateGitVersionInformation_WithIntermediateOutputPath()
    {
        var buildEngine = new Mock<IBuildEngine>();
        var task = new GenerateGitVersionInformation
        {
            BuildEngine = buildEngine.Object,
            VersionFile = GetVersionFile(),
            SolutionDirectory = TestContext.TestRunDirectory!,
            IntermediateOutputPath = Path.Combine(TestContext.TestRunDirectory!, TestContext.TestName!)
        };
        var result = task.Execute();
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void GenerateGitVersionInformation_UnknownLanguage()
    {
        var buildEngine = new Mock<IBuildEngine>();
        var task = new GenerateGitVersionInformation
        {
            BuildEngine = buildEngine.Object,
            VersionFile = GetVersionFile(),
            SolutionDirectory = TestContext.TestRunDirectory!,
            IntermediateOutputPath = Path.Combine(TestContext.TestRunDirectory!, TestContext.TestName!),
            Language = "Unknown"
        };
        var result = task.Execute();
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void GenerateGitVersionInformation_UseProjectNamespaceForGitVersionInformation_Invalid()
    {
        var buildEngine = new Mock<IBuildEngine>();
        var task = new GenerateGitVersionInformation
        {
            BuildEngine = buildEngine.Object,
            VersionFile = GetVersionFile(),
            SolutionDirectory = TestContext.TestRunDirectory!,
            IntermediateOutputPath = Path.Combine(TestContext.TestRunDirectory!, TestContext.TestName!),
            UseProjectNamespaceForGitVersionInformation = "invalid"
        };
        var result = task.Execute();
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void GenerateGitVersionInformation_UseProjectNamespaceForGitVersionInformation_False()
    {
        var buildEngine = new Mock<IBuildEngine>();
        var task = new GenerateGitVersionInformation
        {
            BuildEngine = buildEngine.Object,
            VersionFile = GetVersionFile(),
            SolutionDirectory = TestContext.TestRunDirectory!,
            IntermediateOutputPath = Path.Combine(TestContext.TestRunDirectory!, TestContext.TestName!),
            UseProjectNamespaceForGitVersionInformation = "false"
        };
        var result = task.Execute();
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void GenerateGitVersionInformation_UseProjectNamespaceForGitVersionInformation_True()
    {
        var buildEngine = new Mock<IBuildEngine>();
        var task = new GenerateGitVersionInformation
        {
            BuildEngine = buildEngine.Object,
            VersionFile = GetVersionFile(),
            SolutionDirectory = TestContext.TestRunDirectory!,
            IntermediateOutputPath = Path.Combine(TestContext.TestRunDirectory!, TestContext.TestName!),
            UseProjectNamespaceForGitVersionInformation = "true",
            RootNamespace = "Test.Namespace"
        };
        var result = task.Execute();
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void GenerateGitVersionInformation_RootNamespace_Empty()
    {
        var buildEngine = new Mock<IBuildEngine>();
        var task = new GenerateGitVersionInformation
        {
            BuildEngine = buildEngine.Object,
            VersionFile = GetVersionFile(),
            SolutionDirectory = TestContext.TestRunDirectory!,
            IntermediateOutputPath = Path.Combine(TestContext.TestRunDirectory!, TestContext.TestName!),
            UseProjectNamespaceForGitVersionInformation = "true",
            ProjectFile = "TestProject.csproj"
        };
        var result = task.Execute();
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void GenerateGitVersionInformation_Twice()
    {
        var buildEngine = new Mock<IBuildEngine>();
        var task = new GenerateGitVersionInformation
        {
            BuildEngine = buildEngine.Object,
            VersionFile = GetVersionFile(),
            SolutionDirectory = TestContext.TestRunDirectory!,
            IntermediateOutputPath = Path.Combine(TestContext.TestRunDirectory!, TestContext.TestName!)
        };
        var result = task.Execute();
        Assert.IsTrue(result);
        result = task.Execute();
        Assert.IsTrue(result);
    }
}
