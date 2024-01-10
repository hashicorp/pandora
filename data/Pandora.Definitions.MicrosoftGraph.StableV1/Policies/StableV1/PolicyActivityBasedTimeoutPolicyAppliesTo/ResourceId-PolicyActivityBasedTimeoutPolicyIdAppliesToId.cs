// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Policies.StableV1.PolicyActivityBasedTimeoutPolicyAppliesTo;

internal class PolicyActivityBasedTimeoutPolicyIdAppliesToId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/policies/activityBasedTimeoutPolicies/{activityBasedTimeoutPolicyId}/appliesTo/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.Static("staticActivityBasedTimeoutPolicies", "activityBasedTimeoutPolicies"),
        ResourceIDSegment.UserSpecified("activityBasedTimeoutPolicyId"),
        ResourceIDSegment.Static("staticAppliesTo", "appliesTo"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
