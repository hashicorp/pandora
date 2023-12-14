// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyActivityBasedTimeoutPolicy;

internal class PolicyActivityBasedTimeoutPolicyId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/policies/activityBasedTimeoutPolicies/{activityBasedTimeoutPolicyId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.Static("staticActivityBasedTimeoutPolicies", "activityBasedTimeoutPolicies"),
        ResourceIDSegment.UserSpecified("activityBasedTimeoutPolicyId")
    };
}
