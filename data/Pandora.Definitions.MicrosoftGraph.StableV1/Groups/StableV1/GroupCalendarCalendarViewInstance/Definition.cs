// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupCalendarCalendarViewInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupCalendarCalendarViewInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdCalendarCalendarViewByIdInstanceByIdAcceptOperation(),
        new CreateGroupByIdCalendarCalendarViewByIdInstanceByIdCancelOperation(),
        new CreateGroupByIdCalendarCalendarViewByIdInstanceByIdDeclineOperation(),
        new CreateGroupByIdCalendarCalendarViewByIdInstanceByIdDismissReminderOperation(),
        new CreateGroupByIdCalendarCalendarViewByIdInstanceByIdForwardOperation(),
        new CreateGroupByIdCalendarCalendarViewByIdInstanceByIdSnoozeReminderOperation(),
        new CreateGroupByIdCalendarCalendarViewByIdInstanceByIdTentativelyAcceptOperation(),
        new GetGroupByIdCalendarCalendarViewByIdInstanceByIdOperation(),
        new GetGroupByIdCalendarCalendarViewByIdInstanceCountOperation(),
        new ListGroupByIdCalendarCalendarViewByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdCalendarCalendarViewByIdInstanceByIdAcceptRequestModel),
        typeof(CreateGroupByIdCalendarCalendarViewByIdInstanceByIdCancelRequestModel),
        typeof(CreateGroupByIdCalendarCalendarViewByIdInstanceByIdDeclineRequestModel),
        typeof(CreateGroupByIdCalendarCalendarViewByIdInstanceByIdForwardRequestModel),
        typeof(CreateGroupByIdCalendarCalendarViewByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateGroupByIdCalendarCalendarViewByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
