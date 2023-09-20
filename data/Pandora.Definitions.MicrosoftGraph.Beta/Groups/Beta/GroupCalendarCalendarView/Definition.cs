// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupCalendarCalendarView;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupCalendarCalendarView";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdCalendarCalendarViewByIdAcceptOperation(),
        new CreateGroupByIdCalendarCalendarViewByIdCancelOperation(),
        new CreateGroupByIdCalendarCalendarViewByIdDeclineOperation(),
        new CreateGroupByIdCalendarCalendarViewByIdDismissReminderOperation(),
        new CreateGroupByIdCalendarCalendarViewByIdForwardOperation(),
        new CreateGroupByIdCalendarCalendarViewByIdSnoozeReminderOperation(),
        new CreateGroupByIdCalendarCalendarViewByIdTentativelyAcceptOperation(),
        new GetGroupByIdCalendarCalendarViewByIdOperation(),
        new GetGroupByIdCalendarCalendarViewCountOperation(),
        new ListGroupByIdCalendarCalendarViewsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdCalendarCalendarViewByIdAcceptRequestModel),
        typeof(CreateGroupByIdCalendarCalendarViewByIdCancelRequestModel),
        typeof(CreateGroupByIdCalendarCalendarViewByIdDeclineRequestModel),
        typeof(CreateGroupByIdCalendarCalendarViewByIdForwardRequestModel),
        typeof(CreateGroupByIdCalendarCalendarViewByIdSnoozeReminderRequestModel),
        typeof(CreateGroupByIdCalendarCalendarViewByIdTentativelyAcceptRequestModel)
    };
}
