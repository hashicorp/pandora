// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnlineMeetingAttendanceReportAttendanceRecord;

internal class UserIdOnlineMeetingIdAttendanceReportIdAttendanceRecordId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/onlineMeetings/{onlineMeetingId}/attendanceReports/{meetingAttendanceReportId}/attendanceRecords/{attendanceRecordId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticOnlineMeetings", "onlineMeetings"),
        ResourceIDSegment.UserSpecified("onlineMeetingId"),
        ResourceIDSegment.Static("staticAttendanceReports", "attendanceReports"),
        ResourceIDSegment.UserSpecified("meetingAttendanceReportId"),
        ResourceIDSegment.Static("staticAttendanceRecords", "attendanceRecords"),
        ResourceIDSegment.UserSpecified("attendanceRecordId")
    };
}
