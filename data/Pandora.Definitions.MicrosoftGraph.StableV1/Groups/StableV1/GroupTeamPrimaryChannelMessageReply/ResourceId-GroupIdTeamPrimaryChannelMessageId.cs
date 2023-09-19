// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupTeamPrimaryChannelMessageReply;

internal class GroupIdTeamPrimaryChannelMessageId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/team/primaryChannel/messages/{chatMessageId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticTeam", "team"),
        ResourceIDSegment.Static("staticPrimaryChannel", "primaryChannel"),
        ResourceIDSegment.Static("staticMessages", "messages"),
        ResourceIDSegment.UserSpecified("chatMessageId")
    };
}
