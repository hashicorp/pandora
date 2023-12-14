// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupCalendarViewExceptionOccurrenceInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupCalendarViewExceptionOccurrenceInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAcceptOperation(),
        new CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdCancelOperation(),
        new CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDeclineOperation(),
        new CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDismissReminderOperation(),
        new CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdForwardOperation(),
        new CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderOperation(),
        new CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptOperation(),
        new GetGroupByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdOperation(),
        new GetGroupByIdCalendarViewByIdExceptionOccurrenceByIdInstanceCountOperation(),
        new ListGroupByIdCalendarViewByIdExceptionOccurrenceByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAcceptRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdCancelRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDeclineRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdForwardRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
