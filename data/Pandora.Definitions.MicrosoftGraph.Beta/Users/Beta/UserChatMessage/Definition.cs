// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserChatMessage;

internal class Definition : ResourceDefinition
{
    public string Name => "UserChatMessage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdChatByIdMessageByIdSoftDeleteOperation(),
        new CreateUserByIdChatByIdMessageByIdUndoSoftDeleteOperation(),
        new CreateUserByIdChatByIdMessageOperation(),
        new DeleteUserByIdChatByIdMessageByIdOperation(),
        new GetUserByIdChatByIdMessageByIdOperation(),
        new GetUserByIdChatByIdMessageCountOperation(),
        new ListUserByIdChatByIdMessagesOperation(),
        new SetUserByIdChatByIdMessageByIdReactionOperation(),
        new UnsetUserByIdChatByIdMessageByIdReactionOperation(),
        new UpdateUserByIdChatByIdMessageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SetUserByIdChatByIdMessageByIdReactionRequestModel),
        typeof(UnsetUserByIdChatByIdMessageByIdReactionRequestModel)
    };
}
