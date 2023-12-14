// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupCalendarEventInstanceExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupCalendarEventInstanceExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdOperation(),
        new GetGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceCountOperation(),
        new ListGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
