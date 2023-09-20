// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnlineMeetingAttendanceReportAttendanceRecord;

internal class ListUserByIdOnlineMeetingByIdAttendanceReportByIdAttendanceRecordsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new UserIdOnlineMeetingIdAttendanceReportId();
    public override Type NestedItemType() => typeof(AttendanceRecordCollectionResponseModel);
    public override string? UriSuffix() => "/attendanceRecords";
}
