// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarGroupCalendarEvent;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarGroupCalendarEvent";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdAcceptOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdCancelOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdDeclineOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdDismissReminderOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdForwardOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdSnoozeReminderOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdTentativelyAcceptOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventOperation(),
        new DeleteMeCalendarGroupByIdCalendarByIdEventByIdOperation(),
        new GetMeCalendarGroupByIdCalendarByIdEventByIdOperation(),
        new GetMeCalendarGroupByIdCalendarByIdEventCountOperation(),
        new ListMeCalendarGroupByIdCalendarByIdEventsOperation(),
        new UpdateMeCalendarGroupByIdCalendarByIdEventByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdAcceptRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdCancelRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdDeclineRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdForwardRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdTentativelyAcceptRequestModel)
    };
}
