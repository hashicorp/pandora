// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarGroupCalendarEventInstanceExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarGroupCalendarEventInstanceExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdOperation(),
        new GetMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceCountOperation(),
        new ListMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
