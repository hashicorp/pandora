// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOnlineMeetingMeetingAttendanceReportAttendanceRecord;

internal class Definition : ResourceDefinition
{
    public string Name => "MeOnlineMeetingMeetingAttendanceReportAttendanceRecord";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeOnlineMeetingByIdMeetingAttendanceReportAttendanceRecordOperation(),
        new DeleteMeOnlineMeetingByIdMeetingAttendanceReportAttendanceRecordByIdOperation(),
        new GetMeOnlineMeetingByIdMeetingAttendanceReportAttendanceRecordByIdOperation(),
        new GetMeOnlineMeetingByIdMeetingAttendanceReportAttendanceRecordCountOperation(),
        new ListMeOnlineMeetingByIdMeetingAttendanceReportAttendanceRecordsOperation(),
        new UpdateMeOnlineMeetingByIdMeetingAttendanceReportAttendanceRecordByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
