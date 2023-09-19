// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnenoteSectionGroupSectionPage;

internal class Definition : ResourceDefinition
{
    public string Name => "UserOnenoteSectionGroupSectionPage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdOnenoteSectionGroupByIdSectionByIdPageByIdCopyToSectionOperation(),
        new CreateUserByIdOnenoteSectionGroupByIdSectionByIdPageByIdOnenotePatchContentOperation(),
        new CreateUserByIdOnenoteSectionGroupByIdSectionByIdPageOperation(),
        new DeleteUserByIdOnenoteSectionGroupByIdSectionByIdPageByIdOperation(),
        new GetUserByIdOnenoteSectionGroupByIdSectionByIdPageByIdOperation(),
        new GetUserByIdOnenoteSectionGroupByIdSectionByIdPageCountOperation(),
        new ListUserByIdOnenoteSectionGroupByIdSectionByIdPagesOperation(),
        new UpdateUserByIdOnenoteSectionGroupByIdSectionByIdPageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdOnenoteSectionGroupByIdSectionByIdPageByIdCopyToSectionRequestModel),
        typeof(CreateUserByIdOnenoteSectionGroupByIdSectionByIdPageByIdOnenotePatchContentRequestModel)
    };
}
