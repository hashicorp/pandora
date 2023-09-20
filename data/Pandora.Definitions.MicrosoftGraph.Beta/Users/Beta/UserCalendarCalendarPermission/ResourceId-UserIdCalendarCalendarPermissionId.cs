// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarCalendarPermission;

internal class UserIdCalendarCalendarPermissionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/calendar/calendarPermissions/{calendarPermissionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticCalendar", "calendar"),
        ResourceIDSegment.Static("staticCalendarPermissions", "calendarPermissions"),
        ResourceIDSegment.UserSpecified("calendarPermissionId")
    };
}
