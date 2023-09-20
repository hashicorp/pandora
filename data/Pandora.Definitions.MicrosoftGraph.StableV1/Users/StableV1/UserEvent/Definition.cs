// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserEvent;

internal class Definition : ResourceDefinition
{
    public string Name => "UserEvent";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdEventByIdAcceptOperation(),
        new CreateUserByIdEventByIdCancelOperation(),
        new CreateUserByIdEventByIdDeclineOperation(),
        new CreateUserByIdEventByIdDismissReminderOperation(),
        new CreateUserByIdEventByIdForwardOperation(),
        new CreateUserByIdEventByIdSnoozeReminderOperation(),
        new CreateUserByIdEventByIdTentativelyAcceptOperation(),
        new CreateUserByIdEventOperation(),
        new DeleteUserByIdEventByIdOperation(),
        new GetUserByIdEventByIdOperation(),
        new GetUserByIdEventCountOperation(),
        new ListUserByIdEventsOperation(),
        new UpdateUserByIdEventByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdEventByIdAcceptRequestModel),
        typeof(CreateUserByIdEventByIdCancelRequestModel),
        typeof(CreateUserByIdEventByIdDeclineRequestModel),
        typeof(CreateUserByIdEventByIdForwardRequestModel),
        typeof(CreateUserByIdEventByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdEventByIdTentativelyAcceptRequestModel)
    };
}
