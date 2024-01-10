// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarGroupCalendarEventExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarGroupCalendarEventExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceCountOperation(),
        new ListUserByIdCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
