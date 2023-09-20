// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarCalendarViewExceptionOccurrenceInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarCalendarViewExceptionOccurrenceInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAcceptOperation(),
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdCancelOperation(),
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDeclineOperation(),
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDismissReminderOperation(),
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdForwardOperation(),
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderOperation(),
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAcceptOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdCancelOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDeclineOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDismissReminderOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdForwardOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptOperation(),
        new GetMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceCountOperation(),
        new GetMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdOperation(),
        new GetMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceCountOperation(),
        new ListMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstancesOperation(),
        new ListMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAcceptRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdCancelRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDeclineRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdForwardRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAcceptRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdCancelRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDeclineRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdForwardRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
