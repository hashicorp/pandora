// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarGroupCalendar;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarGroupCalendar";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarGroupByIdCalendarOperation(),
        new DeleteUserByIdCalendarGroupByIdCalendarByIdOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdScheduleOperation(),
        new GetUserByIdCalendarGroupByIdCalendarCountOperation(),
        new ListUserByIdCalendarGroupByIdCalendarsOperation(),
        new UpdateUserByIdCalendarGroupByIdCalendarByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(GetUserByIdCalendarGroupByIdCalendarByIdScheduleRequestModel)
    };
}
