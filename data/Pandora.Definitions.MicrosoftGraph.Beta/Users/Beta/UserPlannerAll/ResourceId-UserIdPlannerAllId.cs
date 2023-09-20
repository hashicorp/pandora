// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPlannerAll;

internal class UserIdPlannerAllId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/planner/all/{plannerDeltaId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticPlanner", "planner"),
        ResourceIDSegment.Static("staticAll", "all"),
        ResourceIDSegment.UserSpecified("plannerDeltaId")
    };
}
