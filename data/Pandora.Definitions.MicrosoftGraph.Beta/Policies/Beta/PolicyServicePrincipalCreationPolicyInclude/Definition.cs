// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyServicePrincipalCreationPolicyInclude;

internal class Definition : ResourceDefinition
{
    public string Name => "PolicyServicePrincipalCreationPolicyInclude";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreatePolicyServicePrincipalCreationPolicyByIdIncludeOperation(),
        new DeletePolicyServicePrincipalCreationPolicyByIdIncludeByIdOperation(),
        new GetPolicyServicePrincipalCreationPolicyByIdIncludeByIdOperation(),
        new GetPolicyServicePrincipalCreationPolicyByIdIncludeCountOperation(),
        new ListPolicyServicePrincipalCreationPolicyByIdIncludesOperation(),
        new UpdatePolicyServicePrincipalCreationPolicyByIdIncludeByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
