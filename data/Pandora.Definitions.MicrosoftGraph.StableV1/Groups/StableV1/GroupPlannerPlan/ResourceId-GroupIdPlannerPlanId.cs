// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupPlannerPlan;

internal class GroupIdPlannerPlanId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/planner/plans/{plannerPlanId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticPlanner", "planner"),
        ResourceIDSegment.Static("staticPlans", "plans"),
        ResourceIDSegment.UserSpecified("plannerPlanId")
    };
}
