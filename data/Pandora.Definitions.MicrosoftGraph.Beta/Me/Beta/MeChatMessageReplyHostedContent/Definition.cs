// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeChatMessageReplyHostedContent;

internal class Definition : ResourceDefinition
{
    public string Name => "MeChatMessageReplyHostedContent";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeChatByIdMessageByIdReplyByIdHostedContentOperation(),
        new CreateUpdateMeChatByIdMessageByIdReplyByIdHostedContentByIdValueOperation(),
        new DeleteMeChatByIdMessageByIdReplyByIdHostedContentByIdOperation(),
        new GetMeChatByIdMessageByIdReplyByIdHostedContentByIdOperation(),
        new GetMeChatByIdMessageByIdReplyByIdHostedContentByIdValueOperation(),
        new GetMeChatByIdMessageByIdReplyByIdHostedContentCountOperation(),
        new ListMeChatByIdMessageByIdReplyByIdHostedContentsOperation(),
        new UpdateMeChatByIdMessageByIdReplyByIdHostedContentByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
