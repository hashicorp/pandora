// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeCalendar;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendar";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarOperation(),
        new DeleteMeCalendarByIdOperation(),
        new GetMeCalendarByIdOperation(),
        new GetMeCalendarByIdScheduleOperation(),
        new GetMeCalendarCountOperation(),
        new GetMeCalendarOperation(),
        new GetMeCalendarScheduleOperation(),
        new ListMeCalendarsOperation(),
        new UpdateMeCalendarByIdOperation(),
        new UpdateMeCalendarOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(GetMeCalendarByIdScheduleRequestModel),
        typeof(GetMeCalendarScheduleRequestModel)
    };
}
