// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserInsightUsedResource;

internal class UserIdInsightUsedId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/insights/used/{usedInsightId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticInsights", "insights"),
        ResourceIDSegment.Static("staticUsed", "used"),
        ResourceIDSegment.UserSpecified("usedInsightId")
    };
}
