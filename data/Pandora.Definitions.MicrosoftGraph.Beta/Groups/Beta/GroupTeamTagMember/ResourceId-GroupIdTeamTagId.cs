// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupTeamTagMember;

internal class GroupIdTeamTagId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/team/tags/{teamworkTagId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticTeam", "team"),
        ResourceIDSegment.Static("staticTags", "tags"),
        ResourceIDSegment.UserSpecified("teamworkTagId")
    };
}
