// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserProfileProject;

internal class Definition : ResourceDefinition
{
    public string Name => "UserProfileProject";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdProfileProjectOperation(),
        new DeleteUserByIdProfileProjectByIdOperation(),
        new GetUserByIdProfileProjectByIdOperation(),
        new GetUserByIdProfileProjectCountOperation(),
        new ListUserByIdProfileProjectsOperation(),
        new UpdateUserByIdProfileProjectByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
