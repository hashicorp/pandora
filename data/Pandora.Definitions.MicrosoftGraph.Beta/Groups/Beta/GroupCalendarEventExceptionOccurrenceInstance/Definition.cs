// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupCalendarEventExceptionOccurrenceInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupCalendarEventExceptionOccurrenceInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdAcceptOperation(),
        new CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdCancelOperation(),
        new CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdDeclineOperation(),
        new CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdDismissReminderOperation(),
        new CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdForwardOperation(),
        new CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderOperation(),
        new CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptOperation(),
        new GetGroupByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdOperation(),
        new GetGroupByIdCalendarEventByIdExceptionOccurrenceByIdInstanceCountOperation(),
        new ListGroupByIdCalendarEventByIdExceptionOccurrenceByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdAcceptRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdCancelRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdDeclineRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdForwardRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
