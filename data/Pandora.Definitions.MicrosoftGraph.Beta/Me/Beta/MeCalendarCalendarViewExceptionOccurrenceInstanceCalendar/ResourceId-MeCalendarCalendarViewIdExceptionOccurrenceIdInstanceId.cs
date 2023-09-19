// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarCalendarViewExceptionOccurrenceInstanceCalendar;

internal class MeCalendarCalendarViewIdExceptionOccurrenceIdInstanceId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/calendar/calendarView/{eventId}/exceptionOccurrences/{eventId1}/instances/{eventId2}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticCalendar", "calendar"),
        ResourceIDSegment.Static("staticCalendarView", "calendarView"),
        ResourceIDSegment.UserSpecified("eventId"),
        ResourceIDSegment.Static("staticExceptionOccurrences", "exceptionOccurrences"),
        ResourceIDSegment.UserSpecified("eventId1"),
        ResourceIDSegment.Static("staticInstances", "instances"),
        ResourceIDSegment.UserSpecified("eventId2")
    };
}
