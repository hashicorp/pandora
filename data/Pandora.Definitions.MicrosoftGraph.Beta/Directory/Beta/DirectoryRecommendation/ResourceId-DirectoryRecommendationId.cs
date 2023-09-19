// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryRecommendation;

internal class DirectoryRecommendationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/directory/recommendations/{recommendationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticRecommendations", "recommendations"),
        ResourceIDSegment.UserSpecified("recommendationId")
    };
}
