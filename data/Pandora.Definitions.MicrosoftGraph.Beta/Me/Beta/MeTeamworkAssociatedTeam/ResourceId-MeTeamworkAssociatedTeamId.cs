// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeTeamworkAssociatedTeam;

internal class MeTeamworkAssociatedTeamId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/teamwork/associatedTeams/{associatedTeamInfoId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticTeamwork", "teamwork"),
        ResourceIDSegment.Static("staticAssociatedTeams", "associatedTeams"),
        ResourceIDSegment.UserSpecified("associatedTeamInfoId")
    };
}
