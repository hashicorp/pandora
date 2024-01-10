// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyAuthenticationMethodsPolicyAuthenticationMethodConfiguration;

internal class Definition : ResourceDefinition
{
    public string Name => "PolicyAuthenticationMethodsPolicyAuthenticationMethodConfiguration";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreatePolicyAuthenticationMethodsPolicyAuthenticationMethodConfigurationOperation(),
        new DeletePolicyAuthenticationMethodsPolicyAuthenticationMethodConfigurationByIdOperation(),
        new GetPolicyAuthenticationMethodsPolicyAuthenticationMethodConfigurationByIdOperation(),
        new GetPolicyAuthenticationMethodsPolicyAuthenticationMethodConfigurationCountOperation(),
        new ListPolicyAuthenticationMethodsPolicyAuthenticationMethodConfigurationsOperation(),
        new UpdatePolicyAuthenticationMethodsPolicyAuthenticationMethodConfigurationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
