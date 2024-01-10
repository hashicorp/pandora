// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeInsightUsedResource;

internal class MeInsightUsedId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/insights/used/{usedInsightId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticInsights", "insights"),
        ResourceIDSegment.Static("staticUsed", "used"),
        ResourceIDSegment.UserSpecified("usedInsightId")
    };
}
