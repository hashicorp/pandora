// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserCalendarGroupCalendarCalendarView;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarGroupCalendarCalendarView";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdAcceptOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdCancelOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdDeclineOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdDismissReminderOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdForwardOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdTentativelyAcceptOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdCalendarViewCountOperation(),
        new ListUserByIdCalendarGroupByIdCalendarByIdCalendarViewsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdTentativelyAcceptRequestModel)
    };
}
