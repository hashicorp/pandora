// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarEventExtension;

internal class MeCalendarIdEventId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/calendars/{calendarId}/events/{eventId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticCalendars", "calendars"),
        ResourceIDSegment.UserSpecified("calendarId"),
        ResourceIDSegment.Static("staticEvents", "events"),
        ResourceIDSegment.UserSpecified("eventId")
    };
}
