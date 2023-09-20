// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnenoteNotebookSectionPage;

internal class Definition : ResourceDefinition
{
    public string Name => "UserOnenoteNotebookSectionPage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdOnenoteNotebookByIdSectionByIdPageByIdCopyToSectionOperation(),
        new CreateUserByIdOnenoteNotebookByIdSectionByIdPageByIdOnenotePatchContentOperation(),
        new CreateUserByIdOnenoteNotebookByIdSectionByIdPageOperation(),
        new DeleteUserByIdOnenoteNotebookByIdSectionByIdPageByIdOperation(),
        new GetUserByIdOnenoteNotebookByIdSectionByIdPageByIdOperation(),
        new GetUserByIdOnenoteNotebookByIdSectionByIdPageCountOperation(),
        new ListUserByIdOnenoteNotebookByIdSectionByIdPagesOperation(),
        new UpdateUserByIdOnenoteNotebookByIdSectionByIdPageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdOnenoteNotebookByIdSectionByIdPageByIdCopyToSectionRequestModel),
        typeof(CreateUserByIdOnenoteNotebookByIdSectionByIdPageByIdOnenotePatchContentRequestModel)
    };
}
