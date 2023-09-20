// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeChatMessageReply;

internal class Definition : ResourceDefinition
{
    public string Name => "MeChatMessageReply";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeChatByIdMessageByIdReplyByIdSoftDeleteOperation(),
        new CreateMeChatByIdMessageByIdReplyByIdUndoSoftDeleteOperation(),
        new CreateMeChatByIdMessageByIdReplyOperation(),
        new DeleteMeChatByIdMessageByIdReplyByIdOperation(),
        new GetMeChatByIdMessageByIdReplyByIdOperation(),
        new GetMeChatByIdMessageByIdReplyCountOperation(),
        new ListMeChatByIdMessageByIdRepliesOperation(),
        new SetMeChatByIdMessageByIdReplyByIdReactionOperation(),
        new UnsetMeChatByIdMessageByIdReplyByIdReactionOperation(),
        new UpdateMeChatByIdMessageByIdReplyByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SetMeChatByIdMessageByIdReplyByIdReactionRequestModel),
        typeof(UnsetMeChatByIdMessageByIdReplyByIdReactionRequestModel)
    };
}
