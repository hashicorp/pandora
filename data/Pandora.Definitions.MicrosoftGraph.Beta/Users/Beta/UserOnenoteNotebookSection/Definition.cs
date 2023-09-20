// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnenoteNotebookSection;

internal class Definition : ResourceDefinition
{
    public string Name => "UserOnenoteNotebookSection";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdOnenoteNotebookByIdSectionByIdCopyToNotebookOperation(),
        new CreateUserByIdOnenoteNotebookByIdSectionByIdCopyToSectionGroupOperation(),
        new CreateUserByIdOnenoteNotebookByIdSectionOperation(),
        new DeleteUserByIdOnenoteNotebookByIdSectionByIdOperation(),
        new GetUserByIdOnenoteNotebookByIdSectionByIdOperation(),
        new GetUserByIdOnenoteNotebookByIdSectionCountOperation(),
        new ListUserByIdOnenoteNotebookByIdSectionsOperation(),
        new UpdateUserByIdOnenoteNotebookByIdSectionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdOnenoteNotebookByIdSectionByIdCopyToNotebookRequestModel),
        typeof(CreateUserByIdOnenoteNotebookByIdSectionByIdCopyToSectionGroupRequestModel)
    };
}
