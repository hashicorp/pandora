// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarCalendarViewInstanceExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarCalendarViewInstanceExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new CreateUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceCountOperation(),
        new GetUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdOperation(),
        new GetUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceCountOperation(),
        new ListUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrencesOperation(),
        new ListUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
