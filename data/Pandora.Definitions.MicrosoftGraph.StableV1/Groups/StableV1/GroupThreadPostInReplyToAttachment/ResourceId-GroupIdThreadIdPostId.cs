// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupThreadPostInReplyToAttachment;

internal class GroupIdThreadIdPostId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/threads/{conversationThreadId}/posts/{postId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticThreads", "threads"),
        ResourceIDSegment.UserSpecified("conversationThreadId"),
        ResourceIDSegment.Static("staticPosts", "posts"),
        ResourceIDSegment.UserSpecified("postId")
    };
}
