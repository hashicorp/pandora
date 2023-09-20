// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserOwnedDevice;

internal class UserIdOwnedDeviceId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/ownedDevices/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticOwnedDevices", "ownedDevices"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
