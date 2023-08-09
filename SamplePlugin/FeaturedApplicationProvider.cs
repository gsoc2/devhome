// Copyright (c) Microsoft Corporation and Contributors
// Licensed under the MIT license.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Windows.DevHome.SDK;
using Windows.Foundation;

namespace SamplePlugin;

public class FeaturedApplicationProvider : IFeaturedApplicationProvider
{
    public IAsyncOperation<IReadOnlyList<IFeaturedApplicationGroup>> GetFeaturedApplicationGroupsAsync()
    {
        return Task.Run<IReadOnlyList<IFeaturedApplicationGroup>>(() =>
        {
            List<string> applications = new ()
            {
                "x-ms-winget://winget/Microsoft.VisualStudio.2022.Community",
                "x-ms-winget://winget/Microsoft.VisualStudioCode",
                "x-ms-winget://winget/Microsoft.PowerShell",
                "x-ms-winget://winget/Git.Git",
                "x-ms-winget://winget/Notepad++.Notepad++",
                "x-ms-winget://winget/Microsoft.SQLServerManagementStudio",
                "x-ms-winget://winget/Microsoft.PowerToys",
                "x-ms-winget://winget/7zip.7zip",
                "x-ms-winget://winget/Google.AndroidStudio",
                "x-ms-winget://winget/JetBrains.IntelliJIDEA.Community",
                "x-ms-winget://winget/JetBrains.PyCharm.Community",
                "x-ms-winget://winget/Python.Python.3.11",
                "x-ms-winget://winget/Microsoft.DotNet.SDK.7",
                "x-ms-winget://winget/Docker.DockerDesktop",
                "x-ms-winget://winget/PuTTY.PuTTY",
                "x-ms-winget://winget/Unity.Unity.2022",
                "x-ms-winget://winget/Orwell.Dev-C++",
                "x-ms-winget://winget/Codeblocks.Codeblocks",
                "x-ms-winget://winget/SublimeHQ.SublimeText.4",
                "x-ms-winget://winget/vim.vim",
                "x-ms-winget://winget/Postman.Postman",
                "x-ms-winget://winget/GitHub.GitHubDesktop",
                "x-ms-winget://winget/OpenJS.NodeJS",
            };

            return new List<IFeaturedApplicationGroup>
            {
                new FeaturedApplicationGroup(
                    "Sample plugin featured applications",
                    "List of featured application from sample plugin",
                    applications),
            };
        }).AsAsyncOperation();
    }
}

public class FeaturedApplicationGroup : IFeaturedApplicationGroup
{
    private readonly string _title;
    private readonly string _description;
    private readonly IReadOnlyList<string> _applications;

    public FeaturedApplicationGroup(string title, string description, List<string> applications)
    {
        _title = title;
        _description = description;
        _applications = applications;
    }

    public string GetTitle(string preferredlocale) => _title;

    public string GetDescription(string preferredlocale) => _description;

    public IReadOnlyList<string> GetApplications() => _applications;
}
