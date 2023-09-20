// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyHomeRealmDiscoveryPolicyAppliesTo;

internal class PolicyHomeRealmDiscoveryPolicyIdAppliesToId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/policies/homeRealmDiscoveryPolicies/{homeRealmDiscoveryPolicyId}/appliesTo/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.Static("staticHomeRealmDiscoveryPolicies", "homeRealmDiscoveryPolicies"),
        ResourceIDSegment.UserSpecified("homeRealmDiscoveryPolicyId"),
        ResourceIDSegment.Static("staticAppliesTo", "appliesTo"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
