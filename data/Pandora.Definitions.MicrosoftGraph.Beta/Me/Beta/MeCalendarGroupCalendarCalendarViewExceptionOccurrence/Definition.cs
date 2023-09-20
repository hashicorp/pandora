// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarGroupCalendarCalendarViewExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarGroupCalendarCalendarViewExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetMeCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdOperation(),
        new GetMeCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceCountOperation(),
        new ListMeCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
