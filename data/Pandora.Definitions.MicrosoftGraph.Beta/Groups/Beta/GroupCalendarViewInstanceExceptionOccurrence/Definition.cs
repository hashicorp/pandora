// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupCalendarViewInstanceExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupCalendarViewInstanceExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdOperation(),
        new GetGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceCountOperation(),
        new ListGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
