// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeTeamworkInstalledAppTeamsApp;

internal class MeTeamworkInstalledAppId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/teamwork/installedApps/{userScopeTeamsAppInstallationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticTeamwork", "teamwork"),
        ResourceIDSegment.Static("staticInstalledApps", "installedApps"),
        ResourceIDSegment.UserSpecified("userScopeTeamsAppInstallationId")
    };
}
