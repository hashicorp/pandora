// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarGroupCalendarCalendarPermission;

internal class MeCalendarGroupIdCalendarIdCalendarPermissionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/calendarGroups/{calendarGroupId}/calendars/{calendarId}/calendarPermissions/{calendarPermissionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticCalendarGroups", "calendarGroups"),
        ResourceIDSegment.UserSpecified("calendarGroupId"),
        ResourceIDSegment.Static("staticCalendars", "calendars"),
        ResourceIDSegment.UserSpecified("calendarId"),
        ResourceIDSegment.Static("staticCalendarPermissions", "calendarPermissions"),
        ResourceIDSegment.UserSpecified("calendarPermissionId")
    };
}
