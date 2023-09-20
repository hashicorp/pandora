// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserOnlineMeetingAttendanceReport;

internal class ListUserByIdOnlineMeetingByIdAttendanceReportsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new UserIdOnlineMeetingId();
    public override Type NestedItemType() => typeof(MeetingAttendanceReportCollectionResponseModel);
    public override string? UriSuffix() => "/attendanceReports";
}
