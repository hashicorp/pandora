// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserCalendar;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendar";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarOperation(),
        new DeleteUserByIdCalendarByIdOperation(),
        new GetUserByIdCalendarByIdOperation(),
        new GetUserByIdCalendarByIdScheduleOperation(),
        new GetUserByIdCalendarCountOperation(),
        new GetUserByIdCalendarOperation(),
        new GetUserByIdCalendarScheduleOperation(),
        new ListUserByIdCalendarsOperation(),
        new UpdateUserByIdCalendarByIdOperation(),
        new UpdateUserByIdCalendarOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(GetUserByIdCalendarByIdScheduleRequestModel),
        typeof(GetUserByIdCalendarScheduleRequestModel)
    };
}
