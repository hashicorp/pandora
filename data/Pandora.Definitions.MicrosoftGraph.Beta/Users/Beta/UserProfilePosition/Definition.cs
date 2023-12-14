// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserProfilePosition;

internal class Definition : ResourceDefinition
{
    public string Name => "UserProfilePosition";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdProfilePositionOperation(),
        new DeleteUserByIdProfilePositionByIdOperation(),
        new GetUserByIdProfilePositionByIdOperation(),
        new GetUserByIdProfilePositionCountOperation(),
        new ListUserByIdProfilePositionsOperation(),
        new UpdateUserByIdProfilePositionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
