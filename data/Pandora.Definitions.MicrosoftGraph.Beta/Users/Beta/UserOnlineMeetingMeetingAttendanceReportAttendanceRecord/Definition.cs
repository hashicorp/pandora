// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnlineMeetingMeetingAttendanceReportAttendanceRecord;

internal class Definition : ResourceDefinition
{
    public string Name => "UserOnlineMeetingMeetingAttendanceReportAttendanceRecord";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdOnlineMeetingByIdMeetingAttendanceReportAttendanceRecordOperation(),
        new DeleteUserByIdOnlineMeetingByIdMeetingAttendanceReportAttendanceRecordByIdOperation(),
        new GetUserByIdOnlineMeetingByIdMeetingAttendanceReportAttendanceRecordByIdOperation(),
        new GetUserByIdOnlineMeetingByIdMeetingAttendanceReportAttendanceRecordCountOperation(),
        new ListUserByIdOnlineMeetingByIdMeetingAttendanceReportAttendanceRecordsOperation(),
        new UpdateUserByIdOnlineMeetingByIdMeetingAttendanceReportAttendanceRecordByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
