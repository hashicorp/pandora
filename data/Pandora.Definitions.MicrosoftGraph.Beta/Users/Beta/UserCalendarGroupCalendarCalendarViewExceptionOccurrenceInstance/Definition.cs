// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarGroupCalendarCalendarViewExceptionOccurrenceInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarGroupCalendarCalendarViewExceptionOccurrenceInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAcceptOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdCancelOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDeclineOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdForwardOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceCountOperation(),
        new ListUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
