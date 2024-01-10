// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarEvent;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarEvent";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdEventByIdAcceptOperation(),
        new CreateMeCalendarByIdEventByIdCancelOperation(),
        new CreateMeCalendarByIdEventByIdDeclineOperation(),
        new CreateMeCalendarByIdEventByIdDismissReminderOperation(),
        new CreateMeCalendarByIdEventByIdForwardOperation(),
        new CreateMeCalendarByIdEventByIdSnoozeReminderOperation(),
        new CreateMeCalendarByIdEventByIdTentativelyAcceptOperation(),
        new CreateMeCalendarByIdEventOperation(),
        new CreateMeCalendarEventByIdAcceptOperation(),
        new CreateMeCalendarEventByIdCancelOperation(),
        new CreateMeCalendarEventByIdDeclineOperation(),
        new CreateMeCalendarEventByIdDismissReminderOperation(),
        new CreateMeCalendarEventByIdForwardOperation(),
        new CreateMeCalendarEventByIdSnoozeReminderOperation(),
        new CreateMeCalendarEventByIdTentativelyAcceptOperation(),
        new CreateMeCalendarEventOperation(),
        new DeleteMeCalendarByIdEventByIdOperation(),
        new DeleteMeCalendarEventByIdOperation(),
        new GetMeCalendarByIdEventByIdOperation(),
        new GetMeCalendarByIdEventCountOperation(),
        new GetMeCalendarEventByIdOperation(),
        new GetMeCalendarEventCountOperation(),
        new ListMeCalendarByIdEventsOperation(),
        new ListMeCalendarEventsOperation(),
        new UpdateMeCalendarByIdEventByIdOperation(),
        new UpdateMeCalendarEventByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarByIdEventByIdAcceptRequestModel),
        typeof(CreateMeCalendarByIdEventByIdCancelRequestModel),
        typeof(CreateMeCalendarByIdEventByIdDeclineRequestModel),
        typeof(CreateMeCalendarByIdEventByIdForwardRequestModel),
        typeof(CreateMeCalendarByIdEventByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarByIdEventByIdTentativelyAcceptRequestModel),
        typeof(CreateMeCalendarEventByIdAcceptRequestModel),
        typeof(CreateMeCalendarEventByIdCancelRequestModel),
        typeof(CreateMeCalendarEventByIdDeclineRequestModel),
        typeof(CreateMeCalendarEventByIdForwardRequestModel),
        typeof(CreateMeCalendarEventByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarEventByIdTentativelyAcceptRequestModel)
    };
}
