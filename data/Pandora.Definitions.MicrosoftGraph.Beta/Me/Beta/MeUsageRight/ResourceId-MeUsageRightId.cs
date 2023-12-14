// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeUsageRight;

internal class MeUsageRightId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/usageRights/{usageRightId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticUsageRights", "usageRights"),
        ResourceIDSegment.UserSpecified("usageRightId")
    };
}
