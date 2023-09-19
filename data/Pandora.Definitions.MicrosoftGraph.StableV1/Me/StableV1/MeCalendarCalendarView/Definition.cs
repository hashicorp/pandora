// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeCalendarCalendarView;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarCalendarView";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdCalendarViewByIdAcceptOperation(),
        new CreateMeCalendarByIdCalendarViewByIdCancelOperation(),
        new CreateMeCalendarByIdCalendarViewByIdDeclineOperation(),
        new CreateMeCalendarByIdCalendarViewByIdDismissReminderOperation(),
        new CreateMeCalendarByIdCalendarViewByIdForwardOperation(),
        new CreateMeCalendarByIdCalendarViewByIdSnoozeReminderOperation(),
        new CreateMeCalendarByIdCalendarViewByIdTentativelyAcceptOperation(),
        new CreateMeCalendarCalendarViewByIdAcceptOperation(),
        new CreateMeCalendarCalendarViewByIdCancelOperation(),
        new CreateMeCalendarCalendarViewByIdDeclineOperation(),
        new CreateMeCalendarCalendarViewByIdDismissReminderOperation(),
        new CreateMeCalendarCalendarViewByIdForwardOperation(),
        new CreateMeCalendarCalendarViewByIdSnoozeReminderOperation(),
        new CreateMeCalendarCalendarViewByIdTentativelyAcceptOperation(),
        new GetMeCalendarByIdCalendarViewByIdOperation(),
        new GetMeCalendarByIdCalendarViewCountOperation(),
        new GetMeCalendarCalendarViewByIdOperation(),
        new GetMeCalendarCalendarViewCountOperation(),
        new ListMeCalendarByIdCalendarViewsOperation(),
        new ListMeCalendarCalendarViewsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarByIdCalendarViewByIdAcceptRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdCancelRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdDeclineRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdForwardRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarByIdCalendarViewByIdTentativelyAcceptRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdAcceptRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdCancelRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdDeclineRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdForwardRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdTentativelyAcceptRequestModel)
    };
}
