// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupConversationThread;

internal class GroupIdConversationIdThreadId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/conversations/{conversationId}/threads/{conversationThreadId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticConversations", "conversations"),
        ResourceIDSegment.UserSpecified("conversationId"),
        ResourceIDSegment.Static("staticThreads", "threads"),
        ResourceIDSegment.UserSpecified("conversationThreadId")
    };
}
