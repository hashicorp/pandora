// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOnlineMeetingAttendanceReportAttendanceRecord;

internal class CreateMeOnlineMeetingByIdAttendanceReportByIdAttendanceRecordOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(AttendanceRecordModel);
    public override ResourceID? ResourceId() => new MeOnlineMeetingIdAttendanceReportId();
    public override Type? ResponseObject() => typeof(AttendanceRecordModel);
    public override string? UriSuffix() => "/attendanceRecords";
}
