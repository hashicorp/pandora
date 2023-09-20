// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarGroupCalendarEventExceptionOccurrenceInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarGroupCalendarEventExceptionOccurrenceInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdAcceptOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdCancelOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdDeclineOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdDismissReminderOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdForwardOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptOperation(),
        new GetMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdOperation(),
        new GetMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceCountOperation(),
        new ListMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdAcceptRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdCancelRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdDeclineRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdForwardRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
