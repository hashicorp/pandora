// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserNotification;

internal class Definition : ResourceDefinition
{
    public string Name => "UserNotification";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdNotificationOperation(),
        new DeleteUserByIdNotificationByIdOperation(),
        new GetUserByIdNotificationByIdOperation(),
        new GetUserByIdNotificationCountOperation(),
        new ListUserByIdNotificationsOperation(),
        new UpdateUserByIdNotificationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
