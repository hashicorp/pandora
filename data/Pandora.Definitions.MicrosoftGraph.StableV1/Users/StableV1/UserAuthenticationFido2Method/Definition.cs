// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserAuthenticationFido2Method;

internal class Definition : ResourceDefinition
{
    public string Name => "UserAuthenticationFido2Method";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeleteUserByIdAuthenticationFido2MethodByIdOperation(),
        new GetUserByIdAuthenticationFido2MethodByIdOperation(),
        new GetUserByIdAuthenticationFido2MethodCountOperation(),
        new ListUserByIdAuthenticationFido2MethodsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
