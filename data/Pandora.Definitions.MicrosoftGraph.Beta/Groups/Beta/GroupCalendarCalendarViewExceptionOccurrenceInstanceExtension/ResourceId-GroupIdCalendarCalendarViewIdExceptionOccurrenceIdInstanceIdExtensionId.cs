// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupCalendarCalendarViewExceptionOccurrenceInstanceExtension;

internal class GroupIdCalendarCalendarViewIdExceptionOccurrenceIdInstanceIdExtensionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/calendar/calendarView/{eventId}/exceptionOccurrences/{eventId1}/instances/{eventId2}/extensions/{extensionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticCalendar", "calendar"),
        ResourceIDSegment.Static("staticCalendarView", "calendarView"),
        ResourceIDSegment.UserSpecified("eventId"),
        ResourceIDSegment.Static("staticExceptionOccurrences", "exceptionOccurrences"),
        ResourceIDSegment.UserSpecified("eventId1"),
        ResourceIDSegment.Static("staticInstances", "instances"),
        ResourceIDSegment.UserSpecified("eventId2"),
        ResourceIDSegment.Static("staticExtensions", "extensions"),
        ResourceIDSegment.UserSpecified("extensionId")
    };
}
