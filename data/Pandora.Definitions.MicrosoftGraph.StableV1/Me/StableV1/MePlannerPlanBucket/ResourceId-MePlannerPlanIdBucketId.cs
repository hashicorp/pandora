// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MePlannerPlanBucket;

internal class MePlannerPlanIdBucketId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/planner/plans/{plannerPlanId}/buckets/{plannerBucketId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticPlanner", "planner"),
        ResourceIDSegment.Static("staticPlans", "plans"),
        ResourceIDSegment.UserSpecified("plannerPlanId"),
        ResourceIDSegment.Static("staticBuckets", "buckets"),
        ResourceIDSegment.UserSpecified("plannerBucketId")
    };
}
