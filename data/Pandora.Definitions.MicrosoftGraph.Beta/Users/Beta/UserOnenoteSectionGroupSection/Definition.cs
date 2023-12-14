// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnenoteSectionGroupSection;

internal class Definition : ResourceDefinition
{
    public string Name => "UserOnenoteSectionGroupSection";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdOnenoteSectionGroupByIdSectionByIdCopyToNotebookOperation(),
        new CreateUserByIdOnenoteSectionGroupByIdSectionByIdCopyToSectionGroupOperation(),
        new CreateUserByIdOnenoteSectionGroupByIdSectionOperation(),
        new DeleteUserByIdOnenoteSectionGroupByIdSectionByIdOperation(),
        new GetUserByIdOnenoteSectionGroupByIdSectionByIdOperation(),
        new GetUserByIdOnenoteSectionGroupByIdSectionCountOperation(),
        new ListUserByIdOnenoteSectionGroupByIdSectionsOperation(),
        new UpdateUserByIdOnenoteSectionGroupByIdSectionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdOnenoteSectionGroupByIdSectionByIdCopyToNotebookRequestModel),
        typeof(CreateUserByIdOnenoteSectionGroupByIdSectionByIdCopyToSectionGroupRequestModel)
    };
}
