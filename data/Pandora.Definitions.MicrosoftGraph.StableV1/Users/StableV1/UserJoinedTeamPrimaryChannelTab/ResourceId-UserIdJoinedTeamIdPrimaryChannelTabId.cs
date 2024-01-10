// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamPrimaryChannelTab;

internal class UserIdJoinedTeamIdPrimaryChannelTabId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/joinedTeams/{teamId}/primaryChannel/tabs/{teamsTabId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticJoinedTeams", "joinedTeams"),
        ResourceIDSegment.UserSpecified("teamId"),
        ResourceIDSegment.Static("staticPrimaryChannel", "primaryChannel"),
        ResourceIDSegment.Static("staticTabs", "tabs"),
        ResourceIDSegment.UserSpecified("teamsTabId")
    };
}
