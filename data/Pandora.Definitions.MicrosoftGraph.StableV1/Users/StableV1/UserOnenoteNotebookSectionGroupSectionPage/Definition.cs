// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserOnenoteNotebookSectionGroupSectionPage;

internal class Definition : ResourceDefinition
{
    public string Name => "UserOnenoteNotebookSectionGroupSectionPage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdCopyToSectionOperation(),
        new CreateUserByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdOnenotePatchContentOperation(),
        new CreateUserByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageOperation(),
        new DeleteUserByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdOperation(),
        new GetUserByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdOperation(),
        new GetUserByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageCountOperation(),
        new ListUserByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPagesOperation(),
        new UpdateUserByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdCopyToSectionRequestModel),
        typeof(CreateUserByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdOnenotePatchContentRequestModel)
    };
}
