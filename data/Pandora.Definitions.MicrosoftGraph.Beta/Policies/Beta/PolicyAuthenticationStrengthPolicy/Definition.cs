// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyAuthenticationStrengthPolicy;

internal class Definition : ResourceDefinition
{
    public string Name => "PolicyAuthenticationStrengthPolicy";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreatePolicyAuthenticationStrengthPolicyOperation(),
        new DeletePolicyAuthenticationStrengthPolicyByIdOperation(),
        new GetPolicyAuthenticationStrengthPolicyByIdOperation(),
        new GetPolicyAuthenticationStrengthPolicyCountOperation(),
        new ListPolicyAuthenticationStrengthPoliciesOperation(),
        new UpdatePolicyAuthenticationStrengthPolicyByIdAllowedCombinationOperation(),
        new UpdatePolicyAuthenticationStrengthPolicyByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(UpdatePolicyAuthenticationStrengthPolicyByIdAllowedCombinationRequestAllowedCombinationsConstant)
    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(UpdatePolicyAuthenticationStrengthPolicyByIdAllowedCombinationRequestModel)
    };
}
