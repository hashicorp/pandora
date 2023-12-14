// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnenotePage;

internal class Definition : ResourceDefinition
{
    public string Name => "UserOnenotePage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdOnenotePageByIdCopyToSectionOperation(),
        new CreateUserByIdOnenotePageByIdOnenotePatchContentOperation(),
        new CreateUserByIdOnenotePageOperation(),
        new DeleteUserByIdOnenotePageByIdOperation(),
        new GetUserByIdOnenotePageByIdOperation(),
        new GetUserByIdOnenotePageCountOperation(),
        new ListUserByIdOnenotePagesOperation(),
        new UpdateUserByIdOnenotePageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdOnenotePageByIdCopyToSectionRequestModel),
        typeof(CreateUserByIdOnenotePageByIdOnenotePatchContentRequestModel)
    };
}
