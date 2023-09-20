// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyTokenIssuancePolicy;

internal class Definition : ResourceDefinition
{
    public string Name => "PolicyTokenIssuancePolicy";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreatePolicyTokenIssuancePolicyOperation(),
        new DeletePolicyTokenIssuancePolicyByIdOperation(),
        new GetPolicyTokenIssuancePolicyByIdOperation(),
        new GetPolicyTokenIssuancePolicyCountOperation(),
        new ListPolicyTokenIssuancePoliciesOperation(),
        new UpdatePolicyTokenIssuancePolicyByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
