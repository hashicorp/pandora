// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Policies.StableV1.PolicyAuthenticationStrengthPolicyCombinationConfiguration;

internal class Definition : ResourceDefinition
{
    public string Name => "PolicyAuthenticationStrengthPolicyCombinationConfiguration";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreatePolicyAuthenticationStrengthPolicyByIdCombinationConfigurationOperation(),
        new DeletePolicyAuthenticationStrengthPolicyByIdCombinationConfigurationByIdOperation(),
        new GetPolicyAuthenticationStrengthPolicyByIdCombinationConfigurationByIdOperation(),
        new GetPolicyAuthenticationStrengthPolicyByIdCombinationConfigurationCountOperation(),
        new ListPolicyAuthenticationStrengthPolicyByIdCombinationConfigurationsOperation(),
        new UpdatePolicyAuthenticationStrengthPolicyByIdCombinationConfigurationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
