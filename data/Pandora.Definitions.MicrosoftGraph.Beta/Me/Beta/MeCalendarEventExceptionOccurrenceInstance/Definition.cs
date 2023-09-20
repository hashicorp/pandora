// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarEventExceptionOccurrenceInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarEventExceptionOccurrenceInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdAcceptOperation(),
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdCancelOperation(),
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdDeclineOperation(),
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdDismissReminderOperation(),
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdForwardOperation(),
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderOperation(),
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdAcceptOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdCancelOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdDeclineOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdDismissReminderOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdForwardOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptOperation(),
        new GetMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdOperation(),
        new GetMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceCountOperation(),
        new GetMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdOperation(),
        new GetMeCalendarEventByIdExceptionOccurrenceByIdInstanceCountOperation(),
        new ListMeCalendarByIdEventByIdExceptionOccurrenceByIdInstancesOperation(),
        new ListMeCalendarEventByIdExceptionOccurrenceByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdAcceptRequestModel),
        typeof(CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdCancelRequestModel),
        typeof(CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdDeclineRequestModel),
        typeof(CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdForwardRequestModel),
        typeof(CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptRequestModel),
        typeof(CreateMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdAcceptRequestModel),
        typeof(CreateMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdCancelRequestModel),
        typeof(CreateMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdDeclineRequestModel),
        typeof(CreateMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdForwardRequestModel),
        typeof(CreateMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
