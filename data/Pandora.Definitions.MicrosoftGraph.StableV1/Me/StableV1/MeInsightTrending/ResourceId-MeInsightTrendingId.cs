// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeInsightTrending;

internal class MeInsightTrendingId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/insights/trending/{trendingId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticInsights", "insights"),
        ResourceIDSegment.Static("staticTrending", "trending"),
        ResourceIDSegment.UserSpecified("trendingId")
    };
}
