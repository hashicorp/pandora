// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityConditionalAccesAuthenticationStrengthPolicy;

internal class Definition : ResourceDefinition
{
    public string Name => "IdentityConditionalAccesAuthenticationStrengthPolicy";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateIdentityConditionalAccesAuthenticationStrengthPolicyOperation(),
        new DeleteIdentityConditionalAccesAuthenticationStrengthPolicyByIdOperation(),
        new GetIdentityConditionalAccesAuthenticationStrengthPolicyByIdOperation(),
        new GetIdentityConditionalAccesAuthenticationStrengthPolicyCountOperation(),
        new ListIdentityConditionalAccesAuthenticationStrengthPoliciesOperation(),
        new UpdateIdentityConditionalAccesAuthenticationStrengthPolicyByIdAllowedCombinationOperation(),
        new UpdateIdentityConditionalAccesAuthenticationStrengthPolicyByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(UpdateIdentityConditionalAccesAuthenticationStrengthPolicyByIdAllowedCombinationRequestAllowedCombinationsConstant)
    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(UpdateIdentityConditionalAccesAuthenticationStrengthPolicyByIdAllowedCombinationRequestModel)
    };
}
