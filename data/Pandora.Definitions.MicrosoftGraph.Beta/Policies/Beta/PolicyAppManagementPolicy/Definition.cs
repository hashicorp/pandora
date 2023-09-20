// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyAppManagementPolicy;

internal class Definition : ResourceDefinition
{
    public string Name => "PolicyAppManagementPolicy";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreatePolicyAppManagementPolicyOperation(),
        new DeletePolicyAppManagementPolicyByIdOperation(),
        new GetPolicyAppManagementPolicyByIdOperation(),
        new GetPolicyAppManagementPolicyCountOperation(),
        new ListPolicyAppManagementPoliciesOperation(),
        new UpdatePolicyAppManagementPolicyByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
