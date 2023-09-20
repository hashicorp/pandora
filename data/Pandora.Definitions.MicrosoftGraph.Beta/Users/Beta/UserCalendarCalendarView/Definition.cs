// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarCalendarView;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarCalendarView";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdCalendarViewByIdAcceptOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdCancelOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdDeclineOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdDismissReminderOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdForwardOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdTentativelyAcceptOperation(),
        new CreateUserByIdCalendarCalendarViewByIdAcceptOperation(),
        new CreateUserByIdCalendarCalendarViewByIdCancelOperation(),
        new CreateUserByIdCalendarCalendarViewByIdDeclineOperation(),
        new CreateUserByIdCalendarCalendarViewByIdDismissReminderOperation(),
        new CreateUserByIdCalendarCalendarViewByIdForwardOperation(),
        new CreateUserByIdCalendarCalendarViewByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarCalendarViewByIdTentativelyAcceptOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewCountOperation(),
        new GetUserByIdCalendarCalendarViewByIdOperation(),
        new GetUserByIdCalendarCalendarViewCountOperation(),
        new ListUserByIdCalendarByIdCalendarViewsOperation(),
        new ListUserByIdCalendarCalendarViewsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdTentativelyAcceptRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdTentativelyAcceptRequestModel)
    };
}
