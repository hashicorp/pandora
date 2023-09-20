// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserDeviceRegisteredOwner;

internal class UserIdDeviceIdRegisteredOwnerId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/devices/{deviceId}/registeredOwners/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticDevices", "devices"),
        ResourceIDSegment.UserSpecified("deviceId"),
        ResourceIDSegment.Static("staticRegisteredOwners", "registeredOwners"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
