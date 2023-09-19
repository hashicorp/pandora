// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupMember;

internal class GroupIdMemberId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/members/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticMembers", "members"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
