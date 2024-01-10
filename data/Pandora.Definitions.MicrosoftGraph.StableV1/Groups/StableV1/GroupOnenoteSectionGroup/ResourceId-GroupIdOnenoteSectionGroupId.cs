// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupOnenoteSectionGroup;

internal class GroupIdOnenoteSectionGroupId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/onenote/sectionGroups/{sectionGroupId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticOnenote", "onenote"),
        ResourceIDSegment.Static("staticSectionGroups", "sectionGroups"),
        ResourceIDSegment.UserSpecified("sectionGroupId")
    };
}
