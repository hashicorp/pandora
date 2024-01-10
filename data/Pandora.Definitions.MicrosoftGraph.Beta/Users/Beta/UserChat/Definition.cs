// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserChat;

internal class Definition : ResourceDefinition
{
    public string Name => "UserChat";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdChatByIdHideForUserOperation(),
        new CreateUserByIdChatByIdMarkChatReadForUserOperation(),
        new CreateUserByIdChatByIdMarkChatUnreadForUserOperation(),
        new CreateUserByIdChatByIdSendActivityNotificationOperation(),
        new CreateUserByIdChatByIdUnhideForUserOperation(),
        new CreateUserByIdChatOperation(),
        new DeleteUserByIdChatByIdOperation(),
        new GetUserByIdChatByIdOperation(),
        new GetUserByIdChatCountOperation(),
        new ListUserByIdChatsOperation(),
        new RemoveUserByIdChatByIdAllAccessForUserOperation(),
        new UpdateUserByIdChatByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdChatByIdHideForUserRequestModel),
        typeof(CreateUserByIdChatByIdMarkChatReadForUserRequestModel),
        typeof(CreateUserByIdChatByIdMarkChatUnreadForUserRequestModel),
        typeof(CreateUserByIdChatByIdSendActivityNotificationRequestModel),
        typeof(CreateUserByIdChatByIdUnhideForUserRequestModel),
        typeof(RemoveUserByIdChatByIdAllAccessForUserRequestModel)
    };
}
