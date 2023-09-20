// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserContactExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "UserContactExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdContactByIdExtensionOperation(),
        new DeleteUserByIdContactByIdExtensionByIdOperation(),
        new GetUserByIdContactByIdExtensionByIdOperation(),
        new GetUserByIdContactByIdExtensionCountOperation(),
        new ListUserByIdContactByIdExtensionsOperation(),
        new UpdateUserByIdContactByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
