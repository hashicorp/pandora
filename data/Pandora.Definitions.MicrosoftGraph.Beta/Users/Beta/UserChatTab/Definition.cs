// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserChatTab;

internal class Definition : ResourceDefinition
{
    public string Name => "UserChatTab";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdChatByIdTabOperation(),
        new DeleteUserByIdChatByIdTabByIdOperation(),
        new GetUserByIdChatByIdTabByIdOperation(),
        new GetUserByIdChatByIdTabCountOperation(),
        new ListUserByIdChatByIdTabsOperation(),
        new UpdateUserByIdChatByIdTabByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
