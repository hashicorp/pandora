// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeAuthenticationFido2Method;

internal class Definition : ResourceDefinition
{
    public string Name => "MeAuthenticationFido2Method";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeleteMeAuthenticationFido2MethodByIdOperation(),
        new GetMeAuthenticationFido2MethodByIdOperation(),
        new GetMeAuthenticationFido2MethodCountOperation(),
        new ListMeAuthenticationFido2MethodsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
