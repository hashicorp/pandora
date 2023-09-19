// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityConditionalAccesPolicy;

internal class Definition : ResourceDefinition
{
    public string Name => "IdentityConditionalAccesPolicy";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateIdentityConditionalAccesPolicyOperation(),
        new DeleteIdentityConditionalAccesPolicyByIdOperation(),
        new GetIdentityConditionalAccesPolicyByIdOperation(),
        new GetIdentityConditionalAccesPolicyCountOperation(),
        new ListIdentityConditionalAccesPoliciesOperation(),
        new UpdateIdentityConditionalAccesPolicyByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
