// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Policies.StableV1.PolicyTokenIssuancePolicyAppliesTo;

internal class PolicyTokenIssuancePolicyId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/policies/tokenIssuancePolicies/{tokenIssuancePolicyId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.Static("staticTokenIssuancePolicies", "tokenIssuancePolicies"),
        ResourceIDSegment.UserSpecified("tokenIssuancePolicyId")
    };
}
