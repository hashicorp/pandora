// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyB2cAuthenticationMethodsPolicy;

internal class Definition : ResourceDefinition
{
    public string Name => "PolicyB2cAuthenticationMethodsPolicy";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeletePolicyB2cAuthenticationMethodsPolicyOperation(),
        new GetPolicyB2cAuthenticationMethodsPolicyOperation(),
        new UpdatePolicyB2cAuthenticationMethodsPolicyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
