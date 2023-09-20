// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeDeviceMemberOf;

internal class MeDeviceIdMemberOfId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/devices/{deviceId}/memberOf/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticDevices", "devices"),
        ResourceIDSegment.UserSpecified("deviceId"),
        ResourceIDSegment.Static("staticMemberOf", "memberOf"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
