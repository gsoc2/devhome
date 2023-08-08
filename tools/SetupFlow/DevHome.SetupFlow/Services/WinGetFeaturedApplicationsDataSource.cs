// Licensed under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevHome.Common.Extensions;
using DevHome.Common.Services;
using DevHome.SetupFlow.Common.Helpers;
using DevHome.SetupFlow.Models;
using Microsoft.Windows.DevHome.SDK;

namespace DevHome.SetupFlow.Services;
public class WinGetFeaturedApplicationsDataSource : WinGetPackageDataSource
{
    private readonly IPluginService _pluginService;
    private readonly IList<IFeaturedApplicationGroup> _groups;

    public WinGetFeaturedApplicationsDataSource(IWindowsPackageManager wpm, IPluginService pluginService)
        : base(wpm)
    {
        _pluginService = pluginService;
        _groups = new List<IFeaturedApplicationGroup>();
    }

    public override int CatalogCount => _groups.Count;

    public async override Task InitializeAsync()
    {
        var plugins = await _pluginService.GetInstalledPluginsAsync(ProviderType.FeaturedApplications);
        foreach (var plugin in plugins)
        {
            var provider = await plugin.GetProviderAsync<IFeaturedApplicationProvider>();
            if (provider != null)
            {
                var groups = await provider.GetFeaturedApplicationGroupsAsync();
                for (var i = 0; i < groups.Count; ++i)
                {
                    _groups.Add(groups[i]);
                }
            }
        }
    }

    public async override Task<IList<PackageCatalog>> LoadCatalogsAsync()
    {
        var result = new List<PackageCatalog>();
        foreach (var group in _groups)
        {
            try
            {
                var packages = await GetPackagesAsync(group.GetApplications().ToList(), id => id);
                if (packages.Any())
                {
                    result.Add(new PackageCatalog()
                    {
                        Name = group.GetTitle(string.Empty),
                        Description = group.GetDescription(string.Empty),
                        Packages = packages.ToReadOnlyCollection(),
                    });
                }
                else
                {
                    Log.Logger?.ReportInfo(Log.Component.AppManagement, "No packages found from restore");
                }
            }
            catch (Exception e)
            {
                Log.Logger?.ReportError(Log.Component.AppManagement, $"Error loading packages from winget restore catalog.", e);
            }
        }

        return result;
    }
}
