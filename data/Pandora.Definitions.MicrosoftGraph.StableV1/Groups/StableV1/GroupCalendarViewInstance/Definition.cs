// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupCalendarViewInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupCalendarViewInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdCalendarViewByIdInstanceByIdAcceptOperation(),
        new CreateGroupByIdCalendarViewByIdInstanceByIdCancelOperation(),
        new CreateGroupByIdCalendarViewByIdInstanceByIdDeclineOperation(),
        new CreateGroupByIdCalendarViewByIdInstanceByIdDismissReminderOperation(),
        new CreateGroupByIdCalendarViewByIdInstanceByIdForwardOperation(),
        new CreateGroupByIdCalendarViewByIdInstanceByIdSnoozeReminderOperation(),
        new CreateGroupByIdCalendarViewByIdInstanceByIdTentativelyAcceptOperation(),
        new GetGroupByIdCalendarViewByIdInstanceByIdOperation(),
        new GetGroupByIdCalendarViewByIdInstanceCountOperation(),
        new ListGroupByIdCalendarViewByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdCalendarViewByIdInstanceByIdAcceptRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdInstanceByIdCancelRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdInstanceByIdDeclineRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdInstanceByIdForwardRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
