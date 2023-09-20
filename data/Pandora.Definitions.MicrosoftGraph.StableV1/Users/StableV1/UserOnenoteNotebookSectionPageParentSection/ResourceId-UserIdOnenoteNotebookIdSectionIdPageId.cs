// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserOnenoteNotebookSectionPageParentSection;

internal class UserIdOnenoteNotebookIdSectionIdPageId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/onenote/notebooks/{notebookId}/sections/{onenoteSectionId}/pages/{onenotePageId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticOnenote", "onenote"),
        ResourceIDSegment.Static("staticNotebooks", "notebooks"),
        ResourceIDSegment.UserSpecified("notebookId"),
        ResourceIDSegment.Static("staticSections", "sections"),
        ResourceIDSegment.UserSpecified("onenoteSectionId"),
        ResourceIDSegment.Static("staticPages", "pages"),
        ResourceIDSegment.UserSpecified("onenotePageId")
    };
}
