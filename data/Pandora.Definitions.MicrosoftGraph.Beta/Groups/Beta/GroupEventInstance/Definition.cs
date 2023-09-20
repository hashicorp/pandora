// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupEventInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupEventInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdEventByIdInstanceByIdAcceptOperation(),
        new CreateGroupByIdEventByIdInstanceByIdCancelOperation(),
        new CreateGroupByIdEventByIdInstanceByIdDeclineOperation(),
        new CreateGroupByIdEventByIdInstanceByIdDismissReminderOperation(),
        new CreateGroupByIdEventByIdInstanceByIdForwardOperation(),
        new CreateGroupByIdEventByIdInstanceByIdSnoozeReminderOperation(),
        new CreateGroupByIdEventByIdInstanceByIdTentativelyAcceptOperation(),
        new GetGroupByIdEventByIdInstanceByIdOperation(),
        new GetGroupByIdEventByIdInstanceCountOperation(),
        new ListGroupByIdEventByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdEventByIdInstanceByIdAcceptRequestModel),
        typeof(CreateGroupByIdEventByIdInstanceByIdCancelRequestModel),
        typeof(CreateGroupByIdEventByIdInstanceByIdDeclineRequestModel),
        typeof(CreateGroupByIdEventByIdInstanceByIdForwardRequestModel),
        typeof(CreateGroupByIdEventByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateGroupByIdEventByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
