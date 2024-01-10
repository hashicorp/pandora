// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Policies.StableV1.PolicyTokenLifetimePolicy;

internal class Definition : ResourceDefinition
{
    public string Name => "PolicyTokenLifetimePolicy";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreatePolicyTokenLifetimePolicyOperation(),
        new DeletePolicyTokenLifetimePolicyByIdOperation(),
        new GetPolicyTokenLifetimePolicyByIdOperation(),
        new GetPolicyTokenLifetimePolicyCountOperation(),
        new ListPolicyTokenLifetimePoliciesOperation(),
        new UpdatePolicyTokenLifetimePolicyByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
