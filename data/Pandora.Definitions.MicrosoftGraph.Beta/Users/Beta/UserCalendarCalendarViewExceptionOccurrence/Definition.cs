// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarCalendarViewExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarCalendarViewExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceCountOperation(),
        new GetUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdOperation(),
        new GetUserByIdCalendarCalendarViewByIdExceptionOccurrenceCountOperation(),
        new ListUserByIdCalendarByIdCalendarViewByIdExceptionOccurrencesOperation(),
        new ListUserByIdCalendarCalendarViewByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
