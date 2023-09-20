// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarEventExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarEventExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetMeCalendarByIdEventByIdExceptionOccurrenceByIdOperation(),
        new GetMeCalendarByIdEventByIdExceptionOccurrenceCountOperation(),
        new GetMeCalendarEventByIdExceptionOccurrenceByIdOperation(),
        new GetMeCalendarEventByIdExceptionOccurrenceCountOperation(),
        new ListMeCalendarByIdEventByIdExceptionOccurrencesOperation(),
        new ListMeCalendarEventByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel),
        typeof(CreateMeCalendarEventByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateMeCalendarEventByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateMeCalendarEventByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateMeCalendarEventByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateMeCalendarEventByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarEventByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
