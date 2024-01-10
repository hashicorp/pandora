// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserDeviceEnrollmentConfigurationAssignment;

internal class UserIdDeviceEnrollmentConfigurationIdAssignmentId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/deviceEnrollmentConfigurations/{deviceEnrollmentConfigurationId}/assignments/{enrollmentConfigurationAssignmentId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticDeviceEnrollmentConfigurations", "deviceEnrollmentConfigurations"),
        ResourceIDSegment.UserSpecified("deviceEnrollmentConfigurationId"),
        ResourceIDSegment.Static("staticAssignments", "assignments"),
        ResourceIDSegment.UserSpecified("enrollmentConfigurationAssignmentId")
    };
}
