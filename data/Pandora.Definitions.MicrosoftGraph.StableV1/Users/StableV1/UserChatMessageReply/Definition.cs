// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserChatMessageReply;

internal class Definition : ResourceDefinition
{
    public string Name => "UserChatMessageReply";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdChatByIdMessageByIdReplyByIdSoftDeleteOperation(),
        new CreateUserByIdChatByIdMessageByIdReplyByIdUndoSoftDeleteOperation(),
        new CreateUserByIdChatByIdMessageByIdReplyOperation(),
        new DeleteUserByIdChatByIdMessageByIdReplyByIdOperation(),
        new GetUserByIdChatByIdMessageByIdReplyByIdOperation(),
        new GetUserByIdChatByIdMessageByIdReplyCountOperation(),
        new ListUserByIdChatByIdMessageByIdRepliesOperation(),
        new SetUserByIdChatByIdMessageByIdReplyByIdReactionOperation(),
        new UnsetUserByIdChatByIdMessageByIdReplyByIdReactionOperation(),
        new UpdateUserByIdChatByIdMessageByIdReplyByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SetUserByIdChatByIdMessageByIdReplyByIdReactionRequestModel),
        typeof(UnsetUserByIdChatByIdMessageByIdReplyByIdReactionRequestModel)
    };
}
