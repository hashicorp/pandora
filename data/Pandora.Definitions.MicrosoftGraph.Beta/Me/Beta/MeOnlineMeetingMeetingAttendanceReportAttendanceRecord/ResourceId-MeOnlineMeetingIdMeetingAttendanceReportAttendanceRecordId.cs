// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOnlineMeetingMeetingAttendanceReportAttendanceRecord;

internal class MeOnlineMeetingIdMeetingAttendanceReportAttendanceRecordId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/onlineMeetings/{onlineMeetingId}/meetingAttendanceReport/attendanceRecords/{attendanceRecordId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticOnlineMeetings", "onlineMeetings"),
        ResourceIDSegment.UserSpecified("onlineMeetingId"),
        ResourceIDSegment.Static("staticMeetingAttendanceReport", "meetingAttendanceReport"),
        ResourceIDSegment.Static("staticAttendanceRecords", "attendanceRecords"),
        ResourceIDSegment.UserSpecified("attendanceRecordId")
    };
}
