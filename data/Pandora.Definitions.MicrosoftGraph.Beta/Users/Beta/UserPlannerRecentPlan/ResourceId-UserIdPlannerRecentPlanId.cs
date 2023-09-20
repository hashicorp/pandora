// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPlannerRecentPlan;

internal class UserIdPlannerRecentPlanId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/planner/recentPlans/{plannerPlanId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticPlanner", "planner"),
        ResourceIDSegment.Static("staticRecentPlans", "recentPlans"),
        ResourceIDSegment.UserSpecified("plannerPlanId")
    };
}
