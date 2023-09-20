// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupConversation;

internal class GroupIdConversationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/conversations/{conversationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticConversations", "conversations"),
        ResourceIDSegment.UserSpecified("conversationId")
    };
}
