// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarCalendarViewInstanceExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarCalendarViewInstanceExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new CreateMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceCountOperation(),
        new GetMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdOperation(),
        new GetMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceCountOperation(),
        new ListMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrencesOperation(),
        new ListMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
