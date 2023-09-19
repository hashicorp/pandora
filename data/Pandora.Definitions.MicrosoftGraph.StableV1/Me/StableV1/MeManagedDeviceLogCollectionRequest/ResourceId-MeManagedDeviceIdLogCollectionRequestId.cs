// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeManagedDeviceLogCollectionRequest;

internal class MeManagedDeviceIdLogCollectionRequestId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/managedDevices/{managedDeviceId}/logCollectionRequests/{deviceLogCollectionResponseId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticManagedDevices", "managedDevices"),
        ResourceIDSegment.UserSpecified("managedDeviceId"),
        ResourceIDSegment.Static("staticLogCollectionRequests", "logCollectionRequests"),
        ResourceIDSegment.UserSpecified("deviceLogCollectionResponseId")
    };
}
