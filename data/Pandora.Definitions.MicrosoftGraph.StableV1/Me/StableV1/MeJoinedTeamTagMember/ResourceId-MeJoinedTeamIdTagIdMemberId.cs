// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamTagMember;

internal class MeJoinedTeamIdTagIdMemberId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/joinedTeams/{teamId}/tags/{teamworkTagId}/members/{teamworkTagMemberId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticJoinedTeams", "joinedTeams"),
        ResourceIDSegment.UserSpecified("teamId"),
        ResourceIDSegment.Static("staticTags", "tags"),
        ResourceIDSegment.UserSpecified("teamworkTagId"),
        ResourceIDSegment.Static("staticMembers", "members"),
        ResourceIDSegment.UserSpecified("teamworkTagMemberId")
    };
}
