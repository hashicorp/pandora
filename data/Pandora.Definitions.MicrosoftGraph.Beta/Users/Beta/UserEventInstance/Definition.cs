// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserEventInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "UserEventInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdEventByIdInstanceByIdAcceptOperation(),
        new CreateUserByIdEventByIdInstanceByIdCancelOperation(),
        new CreateUserByIdEventByIdInstanceByIdDeclineOperation(),
        new CreateUserByIdEventByIdInstanceByIdDismissReminderOperation(),
        new CreateUserByIdEventByIdInstanceByIdForwardOperation(),
        new CreateUserByIdEventByIdInstanceByIdSnoozeReminderOperation(),
        new CreateUserByIdEventByIdInstanceByIdTentativelyAcceptOperation(),
        new GetUserByIdEventByIdInstanceByIdOperation(),
        new GetUserByIdEventByIdInstanceCountOperation(),
        new ListUserByIdEventByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdEventByIdInstanceByIdAcceptRequestModel),
        typeof(CreateUserByIdEventByIdInstanceByIdCancelRequestModel),
        typeof(CreateUserByIdEventByIdInstanceByIdDeclineRequestModel),
        typeof(CreateUserByIdEventByIdInstanceByIdForwardRequestModel),
        typeof(CreateUserByIdEventByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdEventByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
