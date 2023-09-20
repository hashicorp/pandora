// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeCalendarCalendarPermission;

internal class MeCalendarCalendarPermissionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/calendar/calendarPermissions/{calendarPermissionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticCalendar", "calendar"),
        ResourceIDSegment.Static("staticCalendarPermissions", "calendarPermissions"),
        ResourceIDSegment.UserSpecified("calendarPermissionId")
    };
}
