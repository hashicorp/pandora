// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserTodoListExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "UserTodoListExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdTodoListByIdExtensionOperation(),
        new DeleteUserByIdTodoListByIdExtensionByIdOperation(),
        new GetUserByIdTodoListByIdExtensionByIdOperation(),
        new GetUserByIdTodoListByIdExtensionCountOperation(),
        new ListUserByIdTodoListByIdExtensionsOperation(),
        new UpdateUserByIdTodoListByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
