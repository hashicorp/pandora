// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOnenoteNotebookSectionParentSectionGroup;

internal class MeOnenoteNotebookIdSectionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/onenote/notebooks/{notebookId}/sections/{onenoteSectionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticOnenote", "onenote"),
        ResourceIDSegment.Static("staticNotebooks", "notebooks"),
        ResourceIDSegment.UserSpecified("notebookId"),
        ResourceIDSegment.Static("staticSections", "sections"),
        ResourceIDSegment.UserSpecified("onenoteSectionId")
    };
}
