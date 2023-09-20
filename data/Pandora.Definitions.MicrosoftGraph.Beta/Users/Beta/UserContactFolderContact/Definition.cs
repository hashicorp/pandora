// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserContactFolderContact;

internal class Definition : ResourceDefinition
{
    public string Name => "UserContactFolderContact";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdContactFolderByIdContactOperation(),
        new DeleteUserByIdContactFolderByIdContactByIdOperation(),
        new GetUserByIdContactFolderByIdContactByIdOperation(),
        new GetUserByIdContactFolderByIdContactCountOperation(),
        new ListUserByIdContactFolderByIdContactsOperation(),
        new UpdateUserByIdContactFolderByIdContactByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
