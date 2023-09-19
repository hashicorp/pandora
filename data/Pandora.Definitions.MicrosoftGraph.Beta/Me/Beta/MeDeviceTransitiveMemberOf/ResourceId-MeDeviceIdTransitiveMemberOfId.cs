// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeDeviceTransitiveMemberOf;

internal class MeDeviceIdTransitiveMemberOfId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/devices/{deviceId}/transitiveMemberOf/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticDevices", "devices"),
        ResourceIDSegment.UserSpecified("deviceId"),
        ResourceIDSegment.Static("staticTransitiveMemberOf", "transitiveMemberOf"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
