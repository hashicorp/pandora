// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupTeamPrimaryChannelTab;

internal class GroupIdTeamPrimaryChannelTabId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/team/primaryChannel/tabs/{teamsTabId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticTeam", "team"),
        ResourceIDSegment.Static("staticPrimaryChannel", "primaryChannel"),
        ResourceIDSegment.Static("staticTabs", "tabs"),
        ResourceIDSegment.UserSpecified("teamsTabId")
    };
}
