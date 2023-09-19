// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteOnenoteSectionGroupSectionGroup;

internal class GroupIdSiteIdOnenoteSectionGroupIdSectionGroupId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/sites/{siteId}/onenote/sectionGroups/{sectionGroupId}/sectionGroups/{sectionGroupId1}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticSites", "sites"),
        ResourceIDSegment.UserSpecified("siteId"),
        ResourceIDSegment.Static("staticOnenote", "onenote"),
        ResourceIDSegment.Static("staticSectionGroups", "sectionGroups"),
        ResourceIDSegment.UserSpecified("sectionGroupId"),
        ResourceIDSegment.Static("staticSectionGroups", "sectionGroups"),
        ResourceIDSegment.UserSpecified("sectionGroupId1")
    };
}
