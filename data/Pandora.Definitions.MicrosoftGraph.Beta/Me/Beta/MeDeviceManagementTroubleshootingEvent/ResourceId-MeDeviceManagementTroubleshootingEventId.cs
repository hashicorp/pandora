// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeDeviceManagementTroubleshootingEvent;

internal class MeDeviceManagementTroubleshootingEventId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/deviceManagementTroubleshootingEvents/{deviceManagementTroubleshootingEventId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticDeviceManagementTroubleshootingEvents", "deviceManagementTroubleshootingEvents"),
        ResourceIDSegment.UserSpecified("deviceManagementTroubleshootingEventId")
    };
}
