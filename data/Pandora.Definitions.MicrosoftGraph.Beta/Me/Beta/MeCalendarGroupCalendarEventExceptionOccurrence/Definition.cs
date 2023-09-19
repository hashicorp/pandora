// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarGroupCalendarEventExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarGroupCalendarEventExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdOperation(),
        new GetMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceCountOperation(),
        new ListMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
