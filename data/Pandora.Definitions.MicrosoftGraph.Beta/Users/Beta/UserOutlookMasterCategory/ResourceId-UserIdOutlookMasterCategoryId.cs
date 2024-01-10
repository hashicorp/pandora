// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOutlookMasterCategory;

internal class UserIdOutlookMasterCategoryId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/outlook/masterCategories/{outlookCategoryId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticOutlook", "outlook"),
        ResourceIDSegment.Static("staticMasterCategories", "masterCategories"),
        ResourceIDSegment.UserSpecified("outlookCategoryId")
    };
}
