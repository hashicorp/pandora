// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarViewExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarViewExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarViewByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateUserByIdCalendarViewByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateUserByIdCalendarViewByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateUserByIdCalendarViewByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarViewByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateUserByIdCalendarViewByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarViewByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetUserByIdCalendarViewByIdExceptionOccurrenceByIdOperation(),
        new GetUserByIdCalendarViewByIdExceptionOccurrenceCountOperation(),
        new ListUserByIdCalendarViewByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarViewByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarViewByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarViewByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarViewByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarViewByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarViewByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
