// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeCalendarViewInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarViewInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarViewByIdInstanceByIdAcceptOperation(),
        new CreateMeCalendarViewByIdInstanceByIdCancelOperation(),
        new CreateMeCalendarViewByIdInstanceByIdDeclineOperation(),
        new CreateMeCalendarViewByIdInstanceByIdDismissReminderOperation(),
        new CreateMeCalendarViewByIdInstanceByIdForwardOperation(),
        new CreateMeCalendarViewByIdInstanceByIdSnoozeReminderOperation(),
        new CreateMeCalendarViewByIdInstanceByIdTentativelyAcceptOperation(),
        new GetMeCalendarViewByIdInstanceByIdOperation(),
        new GetMeCalendarViewByIdInstanceCountOperation(),
        new ListMeCalendarViewByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarViewByIdInstanceByIdAcceptRequestModel),
        typeof(CreateMeCalendarViewByIdInstanceByIdCancelRequestModel),
        typeof(CreateMeCalendarViewByIdInstanceByIdDeclineRequestModel),
        typeof(CreateMeCalendarViewByIdInstanceByIdForwardRequestModel),
        typeof(CreateMeCalendarViewByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarViewByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
