// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarGroupCalendarCalendarViewInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarGroupCalendarCalendarViewInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdAcceptOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdCancelOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdDeclineOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdDismissReminderOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdForwardOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdSnoozeReminderOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdTentativelyAcceptOperation(),
        new GetMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdOperation(),
        new GetMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceCountOperation(),
        new ListMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdAcceptRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdCancelRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdDeclineRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdForwardRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
