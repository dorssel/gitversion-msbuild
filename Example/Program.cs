// SPDX-FileCopyrightText: 2024 Frans van Dorsselaer
//
// SPDX-License-Identifier: MIT

using System.Diagnostics;
using System.Reflection;

// This is the compile-time available version info.
Console.WriteLine($"FullSemVer: {GitVersionInformation.FullSemVer}");
Console.WriteLine($"InformationalVersion: {GitVersionInformation.InformationalVersion}");

// This is the .NET assembly version info.
Console.WriteLine($"Assembly version: {Assembly.GetExecutingAssembly().GetName().Version}");

// This is the version resource info (Windows only).
var fileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
Console.WriteLine($"FileVersion: {fileVersionInfo.FileVersion}");
Console.WriteLine($"ProductVersion: {fileVersionInfo.ProductVersion}");
