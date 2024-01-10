// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryAttributeSet;

internal class DirectoryAttributeSetId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/directory/attributeSets/{attributeSetId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticAttributeSets", "attributeSets"),
        ResourceIDSegment.UserSpecified("attributeSetId")
    };
}
