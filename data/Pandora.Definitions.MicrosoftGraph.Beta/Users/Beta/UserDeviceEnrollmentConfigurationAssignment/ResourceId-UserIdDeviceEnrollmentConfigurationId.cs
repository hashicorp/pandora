// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserDeviceEnrollmentConfigurationAssignment;

internal class UserIdDeviceEnrollmentConfigurationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/deviceEnrollmentConfigurations/{deviceEnrollmentConfigurationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticDeviceEnrollmentConfigurations", "deviceEnrollmentConfigurations"),
        ResourceIDSegment.UserSpecified("deviceEnrollmentConfigurationId")
    };
}
