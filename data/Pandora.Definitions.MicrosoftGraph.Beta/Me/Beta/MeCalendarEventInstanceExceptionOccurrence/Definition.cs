// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarEventInstanceExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarEventInstanceExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new CreateMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdOperation(),
        new GetMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceCountOperation(),
        new GetMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdOperation(),
        new GetMeCalendarEventByIdInstanceByIdExceptionOccurrenceCountOperation(),
        new ListMeCalendarByIdEventByIdInstanceByIdExceptionOccurrencesOperation(),
        new ListMeCalendarEventByIdInstanceByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel),
        typeof(CreateMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
