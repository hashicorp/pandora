// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarGroupCalendarCalendarViewExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarGroupCalendarCalendarViewExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceCountOperation(),
        new ListUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
