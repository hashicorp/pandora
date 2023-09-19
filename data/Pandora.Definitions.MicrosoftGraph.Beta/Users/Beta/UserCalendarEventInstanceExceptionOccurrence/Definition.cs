// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarEventInstanceExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarEventInstanceExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdOperation(),
        new GetUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceCountOperation(),
        new GetUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdOperation(),
        new GetUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceCountOperation(),
        new ListUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrencesOperation(),
        new ListUserByIdCalendarEventByIdInstanceByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel),
        typeof(CreateUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
