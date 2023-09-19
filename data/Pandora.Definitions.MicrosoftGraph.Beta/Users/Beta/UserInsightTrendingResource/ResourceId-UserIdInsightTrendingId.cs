// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserInsightTrendingResource;

internal class UserIdInsightTrendingId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/insights/trending/{trendingId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticInsights", "insights"),
        ResourceIDSegment.Static("staticTrending", "trending"),
        ResourceIDSegment.UserSpecified("trendingId")
    };
}
