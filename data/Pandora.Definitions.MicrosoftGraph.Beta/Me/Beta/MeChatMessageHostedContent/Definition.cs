// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeChatMessageHostedContent;

internal class Definition : ResourceDefinition
{
    public string Name => "MeChatMessageHostedContent";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeChatByIdMessageByIdHostedContentOperation(),
        new CreateUpdateMeChatByIdMessageByIdHostedContentByIdValueOperation(),
        new DeleteMeChatByIdMessageByIdHostedContentByIdOperation(),
        new GetMeChatByIdMessageByIdHostedContentByIdOperation(),
        new GetMeChatByIdMessageByIdHostedContentByIdValueOperation(),
        new GetMeChatByIdMessageByIdHostedContentCountOperation(),
        new ListMeChatByIdMessageByIdHostedContentsOperation(),
        new UpdateMeChatByIdMessageByIdHostedContentByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
