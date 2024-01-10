// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserProfileInterest;

internal class Definition : ResourceDefinition
{
    public string Name => "UserProfileInterest";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdProfileInterestOperation(),
        new DeleteUserByIdProfileInterestByIdOperation(),
        new GetUserByIdProfileInterestByIdOperation(),
        new GetUserByIdProfileInterestCountOperation(),
        new ListUserByIdProfileInterestsOperation(),
        new UpdateUserByIdProfileInterestByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
