// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarView;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarView";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarViewByIdAcceptOperation(),
        new CreateUserByIdCalendarViewByIdCancelOperation(),
        new CreateUserByIdCalendarViewByIdDeclineOperation(),
        new CreateUserByIdCalendarViewByIdDismissReminderOperation(),
        new CreateUserByIdCalendarViewByIdForwardOperation(),
        new CreateUserByIdCalendarViewByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarViewByIdTentativelyAcceptOperation(),
        new GetUserByIdCalendarViewByIdOperation(),
        new GetUserByIdCalendarViewCountOperation(),
        new ListUserByIdCalendarViewsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarViewByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarViewByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarViewByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarViewByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarViewByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarViewByIdTentativelyAcceptRequestModel)
    };
}
