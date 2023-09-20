// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarGroupCalendar;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarGroupCalendar";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarGroupByIdCalendarOperation(),
        new DeleteMeCalendarGroupByIdCalendarByIdOperation(),
        new GetMeCalendarGroupByIdCalendarByIdOperation(),
        new GetMeCalendarGroupByIdCalendarByIdScheduleOperation(),
        new GetMeCalendarGroupByIdCalendarCountOperation(),
        new ListMeCalendarGroupByIdCalendarsOperation(),
        new UpdateMeCalendarGroupByIdCalendarByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(GetMeCalendarGroupByIdCalendarByIdScheduleRequestModel)
    };
}
