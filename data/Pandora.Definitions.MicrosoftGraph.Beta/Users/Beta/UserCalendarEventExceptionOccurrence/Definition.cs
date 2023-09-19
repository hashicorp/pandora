// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarEventExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarEventExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdOperation(),
        new GetUserByIdCalendarByIdEventByIdExceptionOccurrenceCountOperation(),
        new GetUserByIdCalendarEventByIdExceptionOccurrenceByIdOperation(),
        new GetUserByIdCalendarEventByIdExceptionOccurrenceCountOperation(),
        new ListUserByIdCalendarByIdEventByIdExceptionOccurrencesOperation(),
        new ListUserByIdCalendarEventByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel),
        typeof(CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
