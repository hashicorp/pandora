// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeRegisteredDevice;

internal class MeRegisteredDeviceId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/registeredDevices/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticRegisteredDevices", "registeredDevices"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
