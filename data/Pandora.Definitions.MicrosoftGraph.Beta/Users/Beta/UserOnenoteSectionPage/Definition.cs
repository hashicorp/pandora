// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnenoteSectionPage;

internal class Definition : ResourceDefinition
{
    public string Name => "UserOnenoteSectionPage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdOnenoteSectionByIdPageByIdCopyToSectionOperation(),
        new CreateUserByIdOnenoteSectionByIdPageByIdOnenotePatchContentOperation(),
        new CreateUserByIdOnenoteSectionByIdPageOperation(),
        new DeleteUserByIdOnenoteSectionByIdPageByIdOperation(),
        new GetUserByIdOnenoteSectionByIdPageByIdOperation(),
        new GetUserByIdOnenoteSectionByIdPageCountOperation(),
        new ListUserByIdOnenoteSectionByIdPagesOperation(),
        new UpdateUserByIdOnenoteSectionByIdPageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdOnenoteSectionByIdPageByIdCopyToSectionRequestModel),
        typeof(CreateUserByIdOnenoteSectionByIdPageByIdOnenotePatchContentRequestModel)
    };
}
