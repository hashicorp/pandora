// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOnenotePageParentNotebook;

internal class MeOnenotePageId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/onenote/pages/{onenotePageId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticOnenote", "onenote"),
        ResourceIDSegment.Static("staticPages", "pages"),
        ResourceIDSegment.UserSpecified("onenotePageId")
    };
}
