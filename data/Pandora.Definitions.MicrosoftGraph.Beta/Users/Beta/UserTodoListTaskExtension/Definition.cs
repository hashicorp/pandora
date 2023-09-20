// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserTodoListTaskExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "UserTodoListTaskExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdTodoListByIdTaskByIdExtensionOperation(),
        new DeleteUserByIdTodoListByIdTaskByIdExtensionByIdOperation(),
        new GetUserByIdTodoListByIdTaskByIdExtensionByIdOperation(),
        new GetUserByIdTodoListByIdTaskByIdExtensionCountOperation(),
        new ListUserByIdTodoListByIdTaskByIdExtensionsOperation(),
        new UpdateUserByIdTodoListByIdTaskByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
