// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyPermissionGrantPolicyInclude;

internal class Definition : ResourceDefinition
{
    public string Name => "PolicyPermissionGrantPolicyInclude";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreatePolicyPermissionGrantPolicyByIdIncludeOperation(),
        new DeletePolicyPermissionGrantPolicyByIdIncludeByIdOperation(),
        new GetPolicyPermissionGrantPolicyByIdIncludeByIdOperation(),
        new GetPolicyPermissionGrantPolicyByIdIncludeCountOperation(),
        new ListPolicyPermissionGrantPolicyByIdIncludesOperation(),
        new UpdatePolicyPermissionGrantPolicyByIdIncludeByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
