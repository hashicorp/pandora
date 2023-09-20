// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupTeamChannelMessageReplyHostedContent;

internal class GroupIdTeamChannelIdMessageIdReplyId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/team/channels/{channelId}/messages/{chatMessageId}/replies/{chatMessageId1}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticTeam", "team"),
        ResourceIDSegment.Static("staticChannels", "channels"),
        ResourceIDSegment.UserSpecified("channelId"),
        ResourceIDSegment.Static("staticMessages", "messages"),
        ResourceIDSegment.UserSpecified("chatMessageId"),
        ResourceIDSegment.Static("staticReplies", "replies"),
        ResourceIDSegment.UserSpecified("chatMessageId1")
    };
}
