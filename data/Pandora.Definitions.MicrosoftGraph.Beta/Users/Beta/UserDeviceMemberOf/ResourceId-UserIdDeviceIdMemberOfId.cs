// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserDeviceMemberOf;

internal class UserIdDeviceIdMemberOfId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/devices/{deviceId}/memberOf/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticDevices", "devices"),
        ResourceIDSegment.UserSpecified("deviceId"),
        ResourceIDSegment.Static("staticMemberOf", "memberOf"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
