// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCreatedObject;

internal class MeCreatedObjectId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/createdObjects/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticCreatedObjects", "createdObjects"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
