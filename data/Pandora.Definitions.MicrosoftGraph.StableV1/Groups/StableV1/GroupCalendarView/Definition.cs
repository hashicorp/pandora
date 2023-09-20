// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupCalendarView;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupCalendarView";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdCalendarViewByIdAcceptOperation(),
        new CreateGroupByIdCalendarViewByIdCancelOperation(),
        new CreateGroupByIdCalendarViewByIdDeclineOperation(),
        new CreateGroupByIdCalendarViewByIdDismissReminderOperation(),
        new CreateGroupByIdCalendarViewByIdForwardOperation(),
        new CreateGroupByIdCalendarViewByIdSnoozeReminderOperation(),
        new CreateGroupByIdCalendarViewByIdTentativelyAcceptOperation(),
        new GetGroupByIdCalendarViewByIdOperation(),
        new GetGroupByIdCalendarViewCountOperation(),
        new ListGroupByIdCalendarViewsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdCalendarViewByIdAcceptRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdCancelRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdDeclineRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdForwardRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdSnoozeReminderRequestModel),
        typeof(CreateGroupByIdCalendarViewByIdTentativelyAcceptRequestModel)
    };
}
