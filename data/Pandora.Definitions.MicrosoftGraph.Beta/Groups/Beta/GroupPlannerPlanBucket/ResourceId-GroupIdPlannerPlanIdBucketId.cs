// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupPlannerPlanBucket;

internal class GroupIdPlannerPlanIdBucketId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/planner/plans/{plannerPlanId}/buckets/{plannerBucketId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticPlanner", "planner"),
        ResourceIDSegment.Static("staticPlans", "plans"),
        ResourceIDSegment.UserSpecified("plannerPlanId"),
        ResourceIDSegment.Static("staticBuckets", "buckets"),
        ResourceIDSegment.UserSpecified("plannerBucketId")
    };
}
