// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserDeviceManagementTroubleshootingEvent;

internal class UserIdDeviceManagementTroubleshootingEventId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/deviceManagementTroubleshootingEvents/{deviceManagementTroubleshootingEventId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticDeviceManagementTroubleshootingEvents", "deviceManagementTroubleshootingEvents"),
        ResourceIDSegment.UserSpecified("deviceManagementTroubleshootingEventId")
    };
}
