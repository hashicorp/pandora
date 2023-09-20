// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnenoteNotebook;

internal class Definition : ResourceDefinition
{
    public string Name => "UserOnenoteNotebook";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdOnenoteNotebookByIdCopyNotebookOperation(),
        new CreateUserByIdOnenoteNotebookOperation(),
        new DeleteUserByIdOnenoteNotebookByIdOperation(),
        new GetUserByIdOnenoteNotebookByIdOperation(),
        new GetUserByIdOnenoteNotebookCountOperation(),
        new GetUserByIdOnenoteNotebooksNotebookFromWebUrlOperation(),
        new ListUserByIdOnenoteNotebooksOperation(),
        new UpdateUserByIdOnenoteNotebookByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdOnenoteNotebookByIdCopyNotebookRequestModel),
        typeof(GetUserByIdOnenoteNotebooksNotebookFromWebUrlRequestModel)
    };
}
