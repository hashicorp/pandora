// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupTeamTagMember;

internal class GroupIdTeamTagIdMemberId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/team/tags/{teamworkTagId}/members/{teamworkTagMemberId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticTeam", "team"),
        ResourceIDSegment.Static("staticTags", "tags"),
        ResourceIDSegment.UserSpecified("teamworkTagId"),
        ResourceIDSegment.Static("staticMembers", "members"),
        ResourceIDSegment.UserSpecified("teamworkTagMemberId")
    };
}
