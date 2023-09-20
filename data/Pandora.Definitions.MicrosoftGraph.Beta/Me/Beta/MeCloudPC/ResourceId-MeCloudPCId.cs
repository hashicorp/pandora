// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCloudPC;

internal class MeCloudPCId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/cloudPCs/{cloudPCId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticCloudPCs", "cloudPCs"),
        ResourceIDSegment.UserSpecified("cloudPCId")
    };
}
