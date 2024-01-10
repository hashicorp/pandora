// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyTokenLifetimePolicy;

internal class PolicyTokenLifetimePolicyId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/policies/tokenLifetimePolicies/{tokenLifetimePolicyId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.Static("staticTokenLifetimePolicies", "tokenLifetimePolicies"),
        ResourceIDSegment.UserSpecified("tokenLifetimePolicyId")
    };
}
