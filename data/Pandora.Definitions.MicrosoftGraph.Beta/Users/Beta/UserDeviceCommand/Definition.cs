// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserDeviceCommand;

internal class Definition : ResourceDefinition
{
    public string Name => "UserDeviceCommand";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdDeviceByIdCommandOperation(),
        new DeleteUserByIdDeviceByIdCommandByIdOperation(),
        new GetUserByIdDeviceByIdCommandByIdOperation(),
        new GetUserByIdDeviceByIdCommandCountOperation(),
        new ListUserByIdDeviceByIdCommandsOperation(),
        new UpdateUserByIdDeviceByIdCommandByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
