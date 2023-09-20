// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupEvent;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupEvent";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdEventByIdAcceptOperation(),
        new CreateGroupByIdEventByIdCancelOperation(),
        new CreateGroupByIdEventByIdDeclineOperation(),
        new CreateGroupByIdEventByIdDismissReminderOperation(),
        new CreateGroupByIdEventByIdForwardOperation(),
        new CreateGroupByIdEventByIdSnoozeReminderOperation(),
        new CreateGroupByIdEventByIdTentativelyAcceptOperation(),
        new CreateGroupByIdEventOperation(),
        new DeleteGroupByIdEventByIdOperation(),
        new GetGroupByIdEventByIdOperation(),
        new GetGroupByIdEventCountOperation(),
        new ListGroupByIdEventsOperation(),
        new UpdateGroupByIdEventByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdEventByIdAcceptRequestModel),
        typeof(CreateGroupByIdEventByIdCancelRequestModel),
        typeof(CreateGroupByIdEventByIdDeclineRequestModel),
        typeof(CreateGroupByIdEventByIdForwardRequestModel),
        typeof(CreateGroupByIdEventByIdSnoozeReminderRequestModel),
        typeof(CreateGroupByIdEventByIdTentativelyAcceptRequestModel)
    };
}
