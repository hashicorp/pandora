// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarGroupCalendarEventInstanceExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarGroupCalendarEventInstanceExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceCountOperation(),
        new ListUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
