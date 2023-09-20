// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserProfileAddress;

internal class Definition : ResourceDefinition
{
    public string Name => "UserProfileAddress";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdProfileAddresOperation(),
        new DeleteUserByIdProfileAddressByIdOperation(),
        new GetUserByIdProfileAddressByIdOperation(),
        new GetUserByIdProfileAddressCountOperation(),
        new ListUserByIdProfileAddresOperation(),
        new UpdateUserByIdProfileAddressByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
