// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeDeviceCommandResponsepayload;

internal class MeDeviceIdCommandId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/devices/{deviceId}/commands/{commandId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticDevices", "devices"),
        ResourceIDSegment.UserSpecified("deviceId"),
        ResourceIDSegment.Static("staticCommands", "commands"),
        ResourceIDSegment.UserSpecified("commandId")
    };
}
