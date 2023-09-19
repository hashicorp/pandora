// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupCalendarCalendarViewInstanceExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupCalendarCalendarViewInstanceExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateGroupByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateGroupByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateGroupByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateGroupByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateGroupByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateGroupByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetGroupByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdOperation(),
        new GetGroupByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceCountOperation(),
        new ListGroupByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateGroupByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateGroupByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateGroupByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateGroupByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateGroupByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
