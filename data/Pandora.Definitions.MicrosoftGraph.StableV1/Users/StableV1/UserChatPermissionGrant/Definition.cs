// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserChatPermissionGrant;

internal class Definition : ResourceDefinition
{
    public string Name => "UserChatPermissionGrant";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdChatByIdPermissionGrantOperation(),
        new DeleteUserByIdChatByIdPermissionGrantByIdOperation(),
        new GetUserByIdChatByIdPermissionGrantByIdOperation(),
        new GetUserByIdChatByIdPermissionGrantCountOperation(),
        new ListUserByIdChatByIdPermissionGrantsOperation(),
        new UpdateUserByIdChatByIdPermissionGrantByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
