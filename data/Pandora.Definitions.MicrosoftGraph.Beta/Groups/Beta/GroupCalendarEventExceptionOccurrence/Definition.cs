// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupCalendarEventExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupCalendarEventExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetGroupByIdCalendarEventByIdExceptionOccurrenceByIdOperation(),
        new GetGroupByIdCalendarEventByIdExceptionOccurrenceCountOperation(),
        new ListGroupByIdCalendarEventByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
