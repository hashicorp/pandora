// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MePlannerRosterPlan;

internal class MePlannerRosterPlanId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/planner/rosterPlans/{plannerPlanId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticPlanner", "planner"),
        ResourceIDSegment.Static("staticRosterPlans", "rosterPlans"),
        ResourceIDSegment.UserSpecified("plannerPlanId")
    };
}
