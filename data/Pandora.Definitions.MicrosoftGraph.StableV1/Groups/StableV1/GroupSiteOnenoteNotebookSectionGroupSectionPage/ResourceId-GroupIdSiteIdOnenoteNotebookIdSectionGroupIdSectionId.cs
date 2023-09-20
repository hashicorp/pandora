// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteOnenoteNotebookSectionGroupSectionPage;

internal class GroupIdSiteIdOnenoteNotebookIdSectionGroupIdSectionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/sites/{siteId}/onenote/notebooks/{notebookId}/sectionGroups/{sectionGroupId}/sections/{onenoteSectionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticSites", "sites"),
        ResourceIDSegment.UserSpecified("siteId"),
        ResourceIDSegment.Static("staticOnenote", "onenote"),
        ResourceIDSegment.Static("staticNotebooks", "notebooks"),
        ResourceIDSegment.UserSpecified("notebookId"),
        ResourceIDSegment.Static("staticSectionGroups", "sectionGroups"),
        ResourceIDSegment.UserSpecified("sectionGroupId"),
        ResourceIDSegment.Static("staticSections", "sections"),
        ResourceIDSegment.UserSpecified("onenoteSectionId")
    };
}
