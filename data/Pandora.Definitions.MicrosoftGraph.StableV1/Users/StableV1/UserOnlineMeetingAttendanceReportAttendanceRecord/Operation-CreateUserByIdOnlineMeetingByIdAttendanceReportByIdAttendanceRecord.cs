// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserOnlineMeetingAttendanceReportAttendanceRecord;

internal class CreateUserByIdOnlineMeetingByIdAttendanceReportByIdAttendanceRecordOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(AttendanceRecordModel);
    public override ResourceID? ResourceId() => new UserIdOnlineMeetingIdAttendanceReportId();
    public override Type? ResponseObject() => typeof(AttendanceRecordModel);
    public override string? UriSuffix() => "/attendanceRecords";
}
