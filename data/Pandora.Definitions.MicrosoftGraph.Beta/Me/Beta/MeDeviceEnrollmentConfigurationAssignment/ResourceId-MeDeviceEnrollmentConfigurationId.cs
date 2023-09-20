// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeDeviceEnrollmentConfigurationAssignment;

internal class MeDeviceEnrollmentConfigurationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/deviceEnrollmentConfigurations/{deviceEnrollmentConfigurationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticDeviceEnrollmentConfigurations", "deviceEnrollmentConfigurations"),
        ResourceIDSegment.UserSpecified("deviceEnrollmentConfigurationId")
    };
}
