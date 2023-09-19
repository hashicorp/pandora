// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarEventInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarEventInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdEventByIdInstanceByIdAcceptOperation(),
        new CreateMeCalendarByIdEventByIdInstanceByIdCancelOperation(),
        new CreateMeCalendarByIdEventByIdInstanceByIdDeclineOperation(),
        new CreateMeCalendarByIdEventByIdInstanceByIdDismissReminderOperation(),
        new CreateMeCalendarByIdEventByIdInstanceByIdForwardOperation(),
        new CreateMeCalendarByIdEventByIdInstanceByIdSnoozeReminderOperation(),
        new CreateMeCalendarByIdEventByIdInstanceByIdTentativelyAcceptOperation(),
        new CreateMeCalendarEventByIdInstanceByIdAcceptOperation(),
        new CreateMeCalendarEventByIdInstanceByIdCancelOperation(),
        new CreateMeCalendarEventByIdInstanceByIdDeclineOperation(),
        new CreateMeCalendarEventByIdInstanceByIdDismissReminderOperation(),
        new CreateMeCalendarEventByIdInstanceByIdForwardOperation(),
        new CreateMeCalendarEventByIdInstanceByIdSnoozeReminderOperation(),
        new CreateMeCalendarEventByIdInstanceByIdTentativelyAcceptOperation(),
        new GetMeCalendarByIdEventByIdInstanceByIdOperation(),
        new GetMeCalendarByIdEventByIdInstanceCountOperation(),
        new GetMeCalendarEventByIdInstanceByIdOperation(),
        new GetMeCalendarEventByIdInstanceCountOperation(),
        new ListMeCalendarByIdEventByIdInstancesOperation(),
        new ListMeCalendarEventByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarByIdEventByIdInstanceByIdAcceptRequestModel),
        typeof(CreateMeCalendarByIdEventByIdInstanceByIdCancelRequestModel),
        typeof(CreateMeCalendarByIdEventByIdInstanceByIdDeclineRequestModel),
        typeof(CreateMeCalendarByIdEventByIdInstanceByIdForwardRequestModel),
        typeof(CreateMeCalendarByIdEventByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarByIdEventByIdInstanceByIdTentativelyAcceptRequestModel),
        typeof(CreateMeCalendarEventByIdInstanceByIdAcceptRequestModel),
        typeof(CreateMeCalendarEventByIdInstanceByIdCancelRequestModel),
        typeof(CreateMeCalendarEventByIdInstanceByIdDeclineRequestModel),
        typeof(CreateMeCalendarEventByIdInstanceByIdForwardRequestModel),
        typeof(CreateMeCalendarEventByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarEventByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
