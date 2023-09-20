// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeCalendarCalendarViewInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarCalendarViewInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdCalendarViewByIdInstanceByIdAcceptOperation(),
        new CreateMeCalendarByIdCalendarViewByIdInstanceByIdCancelOperation(),
        new CreateMeCalendarByIdCalendarViewByIdInstanceByIdDeclineOperation(),
        new CreateMeCalendarByIdCalendarViewByIdInstanceByIdDismissReminderOperation(),
        new CreateMeCalendarByIdCalendarViewByIdInstanceByIdForwardOperation(),
        new CreateMeCalendarByIdCalendarViewByIdInstanceByIdSnoozeReminderOperation(),
        new CreateMeCalendarByIdCalendarViewByIdInstanceByIdTentativelyAcceptOperation(),
        new CreateMeCalendarCalendarViewByIdInstanceByIdAcceptOperation(),
        new CreateMeCalendarCalendarViewByIdInstanceByIdCancelOperation(),
        new CreateMeCalendarCalendarViewByIdInstanceByIdDeclineOperation(),
        new CreateMeCalendarCalendarViewByIdInstanceByIdDismissReminderOperation(),
        new CreateMeCalendarCalendarViewByIdInstanceByIdForwardOperation(),
        new CreateMeCalendarCalendarViewByIdInstanceByIdSnoozeReminderOperation(),
        new CreateMeCalendarCalendarViewByIdInstanceByIdTentativelyAcceptOperation(),
        new GetMeCalendarByIdCalendarViewByIdInstanceByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdInstanceCountOperation(),
        new GetMeCalendarCalendarViewByIdInstanceByIdOperation(),
        new GetMeCalendarCalendarViewByIdInstanceCountOperation(),
        new ListMeCalendarByIdCalendarViewByIdInstancesOperation(),
        new ListMeCalendarCalendarViewByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarByIdCalendarViewByIdInstanceByIdAcceptRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdInstanceByIdCancelRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdInstanceByIdDeclineRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdInstanceByIdForwardRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdInstanceByIdTentativelyAcceptRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdInstanceByIdAcceptRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdInstanceByIdCancelRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdInstanceByIdDeclineRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdInstanceByIdForwardRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
