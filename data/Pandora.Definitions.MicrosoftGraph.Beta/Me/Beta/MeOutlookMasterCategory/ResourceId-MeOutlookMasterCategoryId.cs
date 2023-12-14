// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOutlookMasterCategory;

internal class MeOutlookMasterCategoryId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/outlook/masterCategories/{outlookCategoryId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticOutlook", "outlook"),
        ResourceIDSegment.Static("staticMasterCategories", "masterCategories"),
        ResourceIDSegment.UserSpecified("outlookCategoryId")
    };
}
