// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarEventExceptionOccurrenceInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarEventExceptionOccurrenceInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdAcceptOperation(),
        new CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdCancelOperation(),
        new CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdDeclineOperation(),
        new CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdForwardOperation(),
        new CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptOperation(),
        new CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdAcceptOperation(),
        new CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdCancelOperation(),
        new CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdDeclineOperation(),
        new CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdForwardOperation(),
        new CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptOperation(),
        new GetUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdOperation(),
        new GetUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceCountOperation(),
        new GetUserByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdOperation(),
        new GetUserByIdCalendarEventByIdExceptionOccurrenceByIdInstanceCountOperation(),
        new ListUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstancesOperation(),
        new ListUserByIdCalendarEventByIdExceptionOccurrenceByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptRequestModel),
        typeof(CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
