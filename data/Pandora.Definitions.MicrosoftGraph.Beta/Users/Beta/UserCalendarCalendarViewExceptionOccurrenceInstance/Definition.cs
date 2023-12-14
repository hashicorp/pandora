// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarCalendarViewExceptionOccurrenceInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarCalendarViewExceptionOccurrenceInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAcceptOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdCancelOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDeclineOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdForwardOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptOperation(),
        new CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAcceptOperation(),
        new CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdCancelOperation(),
        new CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDeclineOperation(),
        new CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdForwardOperation(),
        new CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceCountOperation(),
        new GetUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdOperation(),
        new GetUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceCountOperation(),
        new ListUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstancesOperation(),
        new ListUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
