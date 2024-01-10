// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeCalendarGroupCalendarCalendarView;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarGroupCalendarCalendarView";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdAcceptOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdCancelOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdDeclineOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdDismissReminderOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdForwardOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdSnoozeReminderOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdTentativelyAcceptOperation(),
        new GetMeCalendarGroupByIdCalendarByIdCalendarViewByIdOperation(),
        new GetMeCalendarGroupByIdCalendarByIdCalendarViewCountOperation(),
        new ListMeCalendarGroupByIdCalendarByIdCalendarViewsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdAcceptRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdCancelRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdDeclineRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdForwardRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdTentativelyAcceptRequestModel)
    };
}
