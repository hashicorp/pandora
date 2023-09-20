// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnenoteSectionGroupParentSectionGroup;

internal class UserIdOnenoteSectionGroupId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/onenote/sectionGroups/{sectionGroupId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticOnenote", "onenote"),
        ResourceIDSegment.Static("staticSectionGroups", "sectionGroups"),
        ResourceIDSegment.UserSpecified("sectionGroupId")
    };
}
