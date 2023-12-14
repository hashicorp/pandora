// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnenoteNotebookSectionGroupSection;

internal class Definition : ResourceDefinition
{
    public string Name => "UserOnenoteNotebookSectionGroupSection";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdCopyToNotebookOperation(),
        new CreateUserByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdCopyToSectionGroupOperation(),
        new CreateUserByIdOnenoteNotebookByIdSectionGroupByIdSectionOperation(),
        new DeleteUserByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdOperation(),
        new GetUserByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdOperation(),
        new GetUserByIdOnenoteNotebookByIdSectionGroupByIdSectionCountOperation(),
        new ListUserByIdOnenoteNotebookByIdSectionGroupByIdSectionsOperation(),
        new UpdateUserByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdCopyToNotebookRequestModel),
        typeof(CreateUserByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdCopyToSectionGroupRequestModel)
    };
}
