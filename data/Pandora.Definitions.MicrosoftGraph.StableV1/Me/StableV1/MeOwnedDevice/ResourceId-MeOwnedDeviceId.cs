// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeOwnedDevice;

internal class MeOwnedDeviceId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/ownedDevices/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticOwnedDevices", "ownedDevices"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
