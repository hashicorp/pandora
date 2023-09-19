// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserTeamworkInstalledAppChat;

internal class UserIdTeamworkInstalledAppId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/teamwork/installedApps/{userScopeTeamsAppInstallationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticTeamwork", "teamwork"),
        ResourceIDSegment.Static("staticInstalledApps", "installedApps"),
        ResourceIDSegment.UserSpecified("userScopeTeamsAppInstallationId")
    };
}
