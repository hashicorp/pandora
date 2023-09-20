// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarViewExceptionOccurrenceInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarViewExceptionOccurrenceInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAcceptOperation(),
        new CreateMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdCancelOperation(),
        new CreateMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDeclineOperation(),
        new CreateMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDismissReminderOperation(),
        new CreateMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdForwardOperation(),
        new CreateMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderOperation(),
        new CreateMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptOperation(),
        new GetMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdOperation(),
        new GetMeCalendarViewByIdExceptionOccurrenceByIdInstanceCountOperation(),
        new ListMeCalendarViewByIdExceptionOccurrenceByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAcceptRequestModel),
        typeof(CreateMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdCancelRequestModel),
        typeof(CreateMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdDeclineRequestModel),
        typeof(CreateMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdForwardRequestModel),
        typeof(CreateMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
