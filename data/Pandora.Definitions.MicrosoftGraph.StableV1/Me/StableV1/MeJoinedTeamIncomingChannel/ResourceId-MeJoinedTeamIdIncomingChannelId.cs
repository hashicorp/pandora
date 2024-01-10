// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamIncomingChannel;

internal class MeJoinedTeamIdIncomingChannelId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/joinedTeams/{teamId}/incomingChannels/{channelId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticJoinedTeams", "joinedTeams"),
        ResourceIDSegment.UserSpecified("teamId"),
        ResourceIDSegment.Static("staticIncomingChannels", "incomingChannels"),
        ResourceIDSegment.UserSpecified("channelId")
    };
}
