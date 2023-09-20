// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeInsightSharedResource;

internal class MeInsightSharedId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/insights/shared/{sharedInsightId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticInsights", "insights"),
        ResourceIDSegment.Static("staticShared", "shared"),
        ResourceIDSegment.UserSpecified("sharedInsightId")
    };
}
