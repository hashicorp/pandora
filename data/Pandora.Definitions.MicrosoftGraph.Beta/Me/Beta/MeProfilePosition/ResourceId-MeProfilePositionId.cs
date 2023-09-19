// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeProfilePosition;

internal class MeProfilePositionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/profile/positions/{workPositionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticProfile", "profile"),
        ResourceIDSegment.Static("staticPositions", "positions"),
        ResourceIDSegment.UserSpecified("workPositionId")
    };
}
