// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupOnenotePageParentNotebook;

internal class GroupIdOnenotePageId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/onenote/pages/{onenotePageId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticOnenote", "onenote"),
        ResourceIDSegment.Static("staticPages", "pages"),
        ResourceIDSegment.UserSpecified("onenotePageId")
    };
}
