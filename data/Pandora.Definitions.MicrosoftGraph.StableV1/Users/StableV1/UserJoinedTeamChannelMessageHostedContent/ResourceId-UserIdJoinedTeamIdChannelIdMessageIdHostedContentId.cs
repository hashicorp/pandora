// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamChannelMessageHostedContent;

internal class UserIdJoinedTeamIdChannelIdMessageIdHostedContentId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/joinedTeams/{teamId}/channels/{channelId}/messages/{chatMessageId}/hostedContents/{chatMessageHostedContentId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticJoinedTeams", "joinedTeams"),
        ResourceIDSegment.UserSpecified("teamId"),
        ResourceIDSegment.Static("staticChannels", "channels"),
        ResourceIDSegment.UserSpecified("channelId"),
        ResourceIDSegment.Static("staticMessages", "messages"),
        ResourceIDSegment.UserSpecified("chatMessageId"),
        ResourceIDSegment.Static("staticHostedContents", "hostedContents"),
        ResourceIDSegment.UserSpecified("chatMessageHostedContentId")
    };
}
