// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserAuthenticationPhoneMethod;

internal class Definition : ResourceDefinition
{
    public string Name => "UserAuthenticationPhoneMethod";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdAuthenticationPhoneMethodByIdDisableSmsSignInOperation(),
        new CreateUserByIdAuthenticationPhoneMethodByIdEnableSmsSignInOperation(),
        new CreateUserByIdAuthenticationPhoneMethodOperation(),
        new DeleteUserByIdAuthenticationPhoneMethodByIdOperation(),
        new GetUserByIdAuthenticationPhoneMethodByIdOperation(),
        new GetUserByIdAuthenticationPhoneMethodCountOperation(),
        new ListUserByIdAuthenticationPhoneMethodsOperation(),
        new UpdateUserByIdAuthenticationPhoneMethodByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
