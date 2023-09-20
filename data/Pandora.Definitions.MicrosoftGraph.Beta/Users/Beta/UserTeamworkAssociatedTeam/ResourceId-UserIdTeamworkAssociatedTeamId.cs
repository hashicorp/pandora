// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserTeamworkAssociatedTeam;

internal class UserIdTeamworkAssociatedTeamId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/teamwork/associatedTeams/{associatedTeamInfoId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticTeamwork", "teamwork"),
        ResourceIDSegment.Static("staticAssociatedTeams", "associatedTeams"),
        ResourceIDSegment.UserSpecified("associatedTeamInfoId")
    };
}
