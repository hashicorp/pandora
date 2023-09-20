// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupCalendarEventInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupCalendarEventInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdCalendarEventByIdInstanceByIdAcceptOperation(),
        new CreateGroupByIdCalendarEventByIdInstanceByIdCancelOperation(),
        new CreateGroupByIdCalendarEventByIdInstanceByIdDeclineOperation(),
        new CreateGroupByIdCalendarEventByIdInstanceByIdDismissReminderOperation(),
        new CreateGroupByIdCalendarEventByIdInstanceByIdForwardOperation(),
        new CreateGroupByIdCalendarEventByIdInstanceByIdSnoozeReminderOperation(),
        new CreateGroupByIdCalendarEventByIdInstanceByIdTentativelyAcceptOperation(),
        new GetGroupByIdCalendarEventByIdInstanceByIdOperation(),
        new GetGroupByIdCalendarEventByIdInstanceCountOperation(),
        new ListGroupByIdCalendarEventByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdCalendarEventByIdInstanceByIdAcceptRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdInstanceByIdCancelRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdInstanceByIdDeclineRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdInstanceByIdForwardRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateGroupByIdCalendarEventByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
