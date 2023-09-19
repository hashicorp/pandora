// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeWindowsInformationProtectionDeviceRegistration;

internal class MeWindowsInformationProtectionDeviceRegistrationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/windowsInformationProtectionDeviceRegistrations/{windowsInformationProtectionDeviceRegistrationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticWindowsInformationProtectionDeviceRegistrations", "windowsInformationProtectionDeviceRegistrations"),
        ResourceIDSegment.UserSpecified("windowsInformationProtectionDeviceRegistrationId")
    };
}
