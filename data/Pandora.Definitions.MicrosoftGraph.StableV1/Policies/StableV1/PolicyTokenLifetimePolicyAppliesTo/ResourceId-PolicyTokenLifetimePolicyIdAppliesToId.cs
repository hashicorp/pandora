// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Policies.StableV1.PolicyTokenLifetimePolicyAppliesTo;

internal class PolicyTokenLifetimePolicyIdAppliesToId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/policies/tokenLifetimePolicies/{tokenLifetimePolicyId}/appliesTo/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.Static("staticTokenLifetimePolicies", "tokenLifetimePolicies"),
        ResourceIDSegment.UserSpecified("tokenLifetimePolicyId"),
        ResourceIDSegment.Static("staticAppliesTo", "appliesTo"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
