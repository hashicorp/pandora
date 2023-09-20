// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserContact;

internal class Definition : ResourceDefinition
{
    public string Name => "UserContact";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdContactOperation(),
        new DeleteUserByIdContactByIdOperation(),
        new GetUserByIdContactByIdOperation(),
        new GetUserByIdContactCountOperation(),
        new ListUserByIdContactsOperation(),
        new UpdateUserByIdContactByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
