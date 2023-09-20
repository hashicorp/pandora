// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserDeviceRegisteredOwner;

internal class Definition : ResourceDefinition
{
    public string Name => "UserDeviceRegisteredOwner";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddUserByIdDeviceByIdRegisteredOwnerRefOperation(),
        new GetUserByIdDeviceByIdRegisteredOwnerCountOperation(),
        new ListUserByIdDeviceByIdRegisteredOwnerRefsOperation(),
        new ListUserByIdDeviceByIdRegisteredOwnersOperation(),
        new RemoveUserByIdDeviceByIdRegisteredOwnerByIdRefOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
