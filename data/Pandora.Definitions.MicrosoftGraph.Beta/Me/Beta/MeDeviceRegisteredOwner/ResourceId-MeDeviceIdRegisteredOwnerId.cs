// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeDeviceRegisteredOwner;

internal class MeDeviceIdRegisteredOwnerId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/devices/{deviceId}/registeredOwners/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticDevices", "devices"),
        ResourceIDSegment.UserSpecified("deviceId"),
        ResourceIDSegment.Static("staticRegisteredOwners", "registeredOwners"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
