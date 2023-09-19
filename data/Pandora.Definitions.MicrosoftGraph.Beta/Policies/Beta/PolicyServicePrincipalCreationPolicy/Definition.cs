// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyServicePrincipalCreationPolicy;

internal class Definition : ResourceDefinition
{
    public string Name => "PolicyServicePrincipalCreationPolicy";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreatePolicyServicePrincipalCreationPolicyOperation(),
        new DeletePolicyServicePrincipalCreationPolicyByIdOperation(),
        new GetPolicyServicePrincipalCreationPolicyByIdOperation(),
        new GetPolicyServicePrincipalCreationPolicyCountOperation(),
        new ListPolicyServicePrincipalCreationPoliciesOperation(),
        new UpdatePolicyServicePrincipalCreationPolicyByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
