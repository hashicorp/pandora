// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupConversationThreadPostInReplyToAttachment;

internal class GroupIdConversationIdThreadIdPostIdInReplyToAttachmentId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/conversations/{conversationId}/threads/{conversationThreadId}/posts/{postId}/inReplyTo/attachments/{attachmentId}";

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
        ResourceIDSegment.Static("staticInReplyTo", "inReplyTo"),
        ResourceIDSegment.Static("staticAttachments", "attachments"),
        ResourceIDSegment.UserSpecified("attachmentId")
    };
}
