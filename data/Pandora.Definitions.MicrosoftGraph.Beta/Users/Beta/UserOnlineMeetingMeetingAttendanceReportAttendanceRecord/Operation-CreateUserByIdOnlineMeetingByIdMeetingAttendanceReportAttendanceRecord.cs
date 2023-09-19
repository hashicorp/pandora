// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnlineMeetingMeetingAttendanceReportAttendanceRecord;

internal class CreateUserByIdOnlineMeetingByIdMeetingAttendanceReportAttendanceRecordOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(AttendanceRecordModel);
    public override ResourceID? ResourceId() => new UserIdOnlineMeetingId();
    public override Type? ResponseObject() => typeof(AttendanceRecordModel);
    public override string? UriSuffix() => "/meetingAttendanceReport/attendanceRecords";
}
