// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupTeamScheduleTimesOff;

internal class GroupIdTeamScheduleTimesOffId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/team/schedule/timesOff/{timeOffId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticTeam", "team"),
        ResourceIDSegment.Static("staticSchedule", "schedule"),
        ResourceIDSegment.Static("staticTimesOff", "timesOff"),
        ResourceIDSegment.UserSpecified("timeOffId")
    };
}
