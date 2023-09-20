// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserWindowsInformationProtectionDeviceRegistration;

internal class UserIdWindowsInformationProtectionDeviceRegistrationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/windowsInformationProtectionDeviceRegistrations/{windowsInformationProtectionDeviceRegistrationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticWindowsInformationProtectionDeviceRegistrations", "windowsInformationProtectionDeviceRegistrations"),
        ResourceIDSegment.UserSpecified("windowsInformationProtectionDeviceRegistrationId")
    };
}
