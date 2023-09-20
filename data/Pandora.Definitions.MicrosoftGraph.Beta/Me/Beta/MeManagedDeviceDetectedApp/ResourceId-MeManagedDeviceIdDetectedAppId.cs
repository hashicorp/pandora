// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeManagedDeviceDetectedApp;

internal class MeManagedDeviceIdDetectedAppId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/managedDevices/{managedDeviceId}/detectedApps/{detectedAppId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticManagedDevices", "managedDevices"),
        ResourceIDSegment.UserSpecified("managedDeviceId"),
        ResourceIDSegment.Static("staticDetectedApps", "detectedApps"),
        ResourceIDSegment.UserSpecified("detectedAppId")
    };
}
