// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupCalendarCalendarViewExtension;

internal class GroupIdCalendarCalendarViewIdExtensionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/calendar/calendarView/{eventId}/extensions/{extensionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticCalendar", "calendar"),
        ResourceIDSegment.Static("staticCalendarView", "calendarView"),
        ResourceIDSegment.UserSpecified("eventId"),
        ResourceIDSegment.Static("staticExtensions", "extensions"),
        ResourceIDSegment.UserSpecified("extensionId")
    };
}
