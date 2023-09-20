// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupCalendarCalendarPermission;

internal class GroupIdCalendarCalendarPermissionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/calendar/calendarPermissions/{calendarPermissionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticCalendar", "calendar"),
        ResourceIDSegment.Static("staticCalendarPermissions", "calendarPermissions"),
        ResourceIDSegment.UserSpecified("calendarPermissionId")
    };
}
