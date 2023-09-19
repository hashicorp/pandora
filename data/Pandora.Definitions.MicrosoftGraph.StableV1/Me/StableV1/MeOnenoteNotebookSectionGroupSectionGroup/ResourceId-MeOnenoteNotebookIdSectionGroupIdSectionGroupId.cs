// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeOnenoteNotebookSectionGroupSectionGroup;

internal class MeOnenoteNotebookIdSectionGroupIdSectionGroupId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/onenote/notebooks/{notebookId}/sectionGroups/{sectionGroupId}/sectionGroups/{sectionGroupId1}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticOnenote", "onenote"),
        ResourceIDSegment.Static("staticNotebooks", "notebooks"),
        ResourceIDSegment.UserSpecified("notebookId"),
        ResourceIDSegment.Static("staticSectionGroups", "sectionGroups"),
        ResourceIDSegment.UserSpecified("sectionGroupId"),
        ResourceIDSegment.Static("staticSectionGroups", "sectionGroups"),
        ResourceIDSegment.UserSpecified("sectionGroupId1")
    };
}
