// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserChatMessageHostedContent;

internal class Definition : ResourceDefinition
{
    public string Name => "UserChatMessageHostedContent";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUpdateUserByIdChatByIdMessageByIdHostedContentByIdValueOperation(),
        new CreateUserByIdChatByIdMessageByIdHostedContentOperation(),
        new DeleteUserByIdChatByIdMessageByIdHostedContentByIdOperation(),
        new GetUserByIdChatByIdMessageByIdHostedContentByIdOperation(),
        new GetUserByIdChatByIdMessageByIdHostedContentByIdValueOperation(),
        new GetUserByIdChatByIdMessageByIdHostedContentCountOperation(),
        new ListUserByIdChatByIdMessageByIdHostedContentsOperation(),
        new UpdateUserByIdChatByIdMessageByIdHostedContentByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
