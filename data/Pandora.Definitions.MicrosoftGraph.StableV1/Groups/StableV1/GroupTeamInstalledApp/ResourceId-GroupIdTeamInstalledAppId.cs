// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupTeamInstalledApp;

internal class GroupIdTeamInstalledAppId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/team/installedApps/{teamsAppInstallationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticTeam", "team"),
        ResourceIDSegment.Static("staticInstalledApps", "installedApps"),
        ResourceIDSegment.UserSpecified("teamsAppInstallationId")
    };
}
