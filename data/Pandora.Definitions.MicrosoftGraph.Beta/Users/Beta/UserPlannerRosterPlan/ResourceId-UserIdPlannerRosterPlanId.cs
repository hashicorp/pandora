// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPlannerRosterPlan;

internal class UserIdPlannerRosterPlanId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/planner/rosterPlans/{plannerPlanId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticPlanner", "planner"),
        ResourceIDSegment.Static("staticRosterPlans", "rosterPlans"),
        ResourceIDSegment.UserSpecified("plannerPlanId")
    };
}
