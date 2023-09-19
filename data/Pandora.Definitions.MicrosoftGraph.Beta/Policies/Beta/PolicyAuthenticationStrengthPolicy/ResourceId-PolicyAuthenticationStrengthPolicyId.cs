// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyAuthenticationStrengthPolicy;

internal class PolicyAuthenticationStrengthPolicyId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/policies/authenticationStrengthPolicies/{authenticationStrengthPolicyId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.Static("staticAuthenticationStrengthPolicies", "authenticationStrengthPolicies"),
        ResourceIDSegment.UserSpecified("authenticationStrengthPolicyId")
    };
}
