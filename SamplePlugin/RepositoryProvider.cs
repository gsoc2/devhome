// Copyright (c) Microsoft Corporation and Contributors
// Licensed under the MIT license.

using System;
using System.Collections.Generic;
using Microsoft.Windows.DevHome.SDK;
using Windows.Foundation;

namespace SamplePlugin;
internal class RepositoryProvider : IRepositoryProvider
{
    public string DisplayName => "Repository Provider";

    public IAsyncOperation<IEnumerable<IRepository>> GetRepositoriesAsync(IDeveloperId developerId) => throw new NotImplementedException();

    public IAsyncOperation<IRepository> ParseRepositoryFromUrlAsync(Uri uri) => throw new NotImplementedException();
}
