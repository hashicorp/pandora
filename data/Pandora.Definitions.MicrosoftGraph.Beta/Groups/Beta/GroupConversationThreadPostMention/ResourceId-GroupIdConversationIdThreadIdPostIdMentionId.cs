// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupConversationThreadPostMention;

internal class GroupIdConversationIdThreadIdPostIdMentionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/conversations/{conversationId}/threads/{conversationThreadId}/posts/{postId}/mentions/{mentionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticConversations", "conversations"),
        ResourceIDSegment.UserSpecified("conversationId"),
        ResourceIDSegment.Static("staticThreads", "threads"),
        ResourceIDSegment.UserSpecified("conversationThreadId"),
        ResourceIDSegment.Static("staticPosts", "posts"),
        ResourceIDSegment.UserSpecified("postId"),
        ResourceIDSegment.Static("staticMentions", "mentions"),
        ResourceIDSegment.UserSpecified("mentionId")
    };
}
