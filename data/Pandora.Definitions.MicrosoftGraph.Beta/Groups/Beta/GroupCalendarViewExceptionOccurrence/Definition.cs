// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupCalendarViewExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupCalendarViewExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetGroupByIdCalendarViewByIdExceptionOccurrenceByIdOperation(),
        new GetGroupByIdCalendarViewByIdExceptionOccurrenceCountOperation(),
        new ListGroupByIdCalendarViewByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
