// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarCalendarViewExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarCalendarViewExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdExceptionOccurrenceCountOperation(),
        new GetMeCalendarCalendarViewByIdExceptionOccurrenceByIdOperation(),
        new GetMeCalendarCalendarViewByIdExceptionOccurrenceCountOperation(),
        new ListMeCalendarByIdCalendarViewByIdExceptionOccurrencesOperation(),
        new ListMeCalendarCalendarViewByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
