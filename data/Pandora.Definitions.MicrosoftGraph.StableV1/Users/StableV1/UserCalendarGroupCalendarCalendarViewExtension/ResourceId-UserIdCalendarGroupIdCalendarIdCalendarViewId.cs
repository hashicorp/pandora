// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserCalendarGroupCalendarCalendarViewExtension;

internal class UserIdCalendarGroupIdCalendarIdCalendarViewId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/calendarGroups/{calendarGroupId}/calendars/{calendarId}/calendarView/{eventId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticCalendarGroups", "calendarGroups"),
        ResourceIDSegment.UserSpecified("calendarGroupId"),
        ResourceIDSegment.Static("staticCalendars", "calendars"),
        ResourceIDSegment.UserSpecified("calendarId"),
        ResourceIDSegment.Static("staticCalendarView", "calendarView"),
        ResourceIDSegment.UserSpecified("eventId")
    };
}
