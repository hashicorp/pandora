// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOnlineMeetingAttendanceReport;

internal class MeOnlineMeetingIdAttendanceReportId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/onlineMeetings/{onlineMeetingId}/attendanceReports/{meetingAttendanceReportId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticOnlineMeetings", "onlineMeetings"),
        ResourceIDSegment.UserSpecified("onlineMeetingId"),
        ResourceIDSegment.Static("staticAttendanceReports", "attendanceReports"),
        ResourceIDSegment.UserSpecified("meetingAttendanceReportId")
    };
}
