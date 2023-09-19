// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarCalendarPermission;

internal class UserIdCalendarIdCalendarPermissionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/calendars/{calendarId}/calendarPermissions/{calendarPermissionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticCalendars", "calendars"),
        ResourceIDSegment.UserSpecified("calendarId"),
        ResourceIDSegment.Static("staticCalendarPermissions", "calendarPermissions"),
        ResourceIDSegment.UserSpecified("calendarPermissionId")
    };
}
