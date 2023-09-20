// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MePlannerPlanBucketTaskProgressTaskBoardFormat;

internal class MePlannerPlanIdBucketIdTaskId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/planner/plans/{plannerPlanId}/buckets/{plannerBucketId}/tasks/{plannerTaskId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticPlanner", "planner"),
        ResourceIDSegment.Static("staticPlans", "plans"),
        ResourceIDSegment.UserSpecified("plannerPlanId"),
        ResourceIDSegment.Static("staticBuckets", "buckets"),
        ResourceIDSegment.UserSpecified("plannerBucketId"),
        ResourceIDSegment.Static("staticTasks", "tasks"),
        ResourceIDSegment.UserSpecified("plannerTaskId")
    };
}
