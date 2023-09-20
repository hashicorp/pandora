// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamChannelMessageReplyHostedContent;

internal class MeJoinedTeamIdChannelIdMessageIdReplyIdHostedContentId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/joinedTeams/{teamId}/channels/{channelId}/messages/{chatMessageId}/replies/{chatMessageId1}/hostedContents/{chatMessageHostedContentId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticJoinedTeams", "joinedTeams"),
        ResourceIDSegment.UserSpecified("teamId"),
        ResourceIDSegment.Static("staticChannels", "channels"),
        ResourceIDSegment.UserSpecified("channelId"),
        ResourceIDSegment.Static("staticMessages", "messages"),
        ResourceIDSegment.UserSpecified("chatMessageId"),
        ResourceIDSegment.Static("staticReplies", "replies"),
        ResourceIDSegment.UserSpecified("chatMessageId1"),
        ResourceIDSegment.Static("staticHostedContents", "hostedContents"),
        ResourceIDSegment.UserSpecified("chatMessageHostedContentId")
    };
}
