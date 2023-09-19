// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserProfileAnniversary;

internal class Definition : ResourceDefinition
{
    public string Name => "UserProfileAnniversary";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdProfileAnniversaryOperation(),
        new DeleteUserByIdProfileAnniversaryByIdOperation(),
        new GetUserByIdProfileAnniversaryByIdOperation(),
        new GetUserByIdProfileAnniversaryCountOperation(),
        new ListUserByIdProfileAnniversariesOperation(),
        new UpdateUserByIdProfileAnniversaryByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
