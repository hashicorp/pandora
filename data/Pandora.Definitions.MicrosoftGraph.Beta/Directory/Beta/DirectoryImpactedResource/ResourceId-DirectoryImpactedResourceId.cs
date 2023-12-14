// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryImpactedResource;

internal class DirectoryImpactedResourceId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/directory/impactedResources/{impactedResourceId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticImpactedResources", "impactedResources"),
        ResourceIDSegment.UserSpecified("impactedResourceId")
    };
}
