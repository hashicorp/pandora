// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyFeatureRolloutPolicy;

internal class PolicyFeatureRolloutPolicyId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/policies/featureRolloutPolicies/{featureRolloutPolicyId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.Static("staticFeatureRolloutPolicies", "featureRolloutPolicies"),
        ResourceIDSegment.UserSpecified("featureRolloutPolicyId")
    };
}
