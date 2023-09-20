// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupTeamIncomingChannel;

internal class GroupIdTeamIncomingChannelId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/team/incomingChannels/{channelId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticTeam", "team"),
        ResourceIDSegment.Static("staticIncomingChannels", "incomingChannels"),
        ResourceIDSegment.UserSpecified("channelId")
    };
}
