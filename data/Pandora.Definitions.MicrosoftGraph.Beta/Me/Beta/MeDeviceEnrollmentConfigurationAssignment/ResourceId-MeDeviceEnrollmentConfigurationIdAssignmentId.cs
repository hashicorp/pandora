// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeDeviceEnrollmentConfigurationAssignment;

internal class MeDeviceEnrollmentConfigurationIdAssignmentId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/deviceEnrollmentConfigurations/{deviceEnrollmentConfigurationId}/assignments/{enrollmentConfigurationAssignmentId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticDeviceEnrollmentConfigurations", "deviceEnrollmentConfigurations"),
        ResourceIDSegment.UserSpecified("deviceEnrollmentConfigurationId"),
        ResourceIDSegment.Static("staticAssignments", "assignments"),
        ResourceIDSegment.UserSpecified("enrollmentConfigurationAssignmentId")
    };
}
