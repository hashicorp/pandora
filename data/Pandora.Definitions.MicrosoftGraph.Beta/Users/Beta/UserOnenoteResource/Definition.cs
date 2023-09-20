// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnenoteResource;

internal class Definition : ResourceDefinition
{
    public string Name => "UserOnenoteResource";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdOnenoteResourceOperation(),
        new DeleteUserByIdOnenoteResourceByIdOperation(),
        new GetUserByIdOnenoteResourceByIdOperation(),
        new GetUserByIdOnenoteResourceCountOperation(),
        new ListUserByIdOnenoteResourcesOperation(),
        new UpdateUserByIdOnenoteResourceByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
