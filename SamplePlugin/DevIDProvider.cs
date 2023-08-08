// Copyright (c) Microsoft Corporation and Contributors
// Licensed under the MIT license.

using System;
using System.Collections.Generic;
using Microsoft.Windows.DevHome.SDK;
using Windows.Foundation;

namespace SamplePlugin;

internal class DevIDProvider : IDeveloperIdProvider
{
    public AuthenticationState developerIDState
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

#pragma warning disable CS0067 // The events are never used
    public event EventHandler<IDeveloperId> LoggedIn;

    public event EventHandler<IDeveloperId> LoggedOut;

    public event EventHandler<IDeveloperId> Updated;

    public event TypedEventHandler<IDeveloperIdProvider, object> Changed;
#pragma warning restore CS0067 // The events are never used

    public IEnumerable<IDeveloperId> GetLoggedInDeveloperIds() => throw new NotImplementedException();

    public string GetName() => "Sample Dev ID Provider";

    public IPluginAdaptiveCardController GetAdaptiveCardController(string[] args)
    {
        if (args.Length > 0 && args[0] == "LoginUI")
        {
            return new LoginUI();
        }

        return null;
    }

    public void LoginNewDeveloperId() => throw new NotImplementedException();

    public void LogoutDeveloperId(IDeveloperId developerId) => throw new NotImplementedException();

    public string LogoutUI() => throw new NotImplementedException();

    public AuthenticationExperienceKind GetAuthenticationExperienceKind() => throw new NotImplementedException();

    public IAsyncOperation<IDeveloperId> LoginNewDeveloperIdAsync() => throw new NotImplementedException();
}
