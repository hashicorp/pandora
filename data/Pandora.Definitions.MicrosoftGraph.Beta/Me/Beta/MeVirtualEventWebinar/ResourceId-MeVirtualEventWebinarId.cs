// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeVirtualEventWebinar;

internal class MeVirtualEventWebinarId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/virtualEvents/webinars/{virtualEventWebinarId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticVirtualEvents", "virtualEvents"),
        ResourceIDSegment.Static("staticWebinars", "webinars"),
        ResourceIDSegment.UserSpecified("virtualEventWebinarId")
    };
}
