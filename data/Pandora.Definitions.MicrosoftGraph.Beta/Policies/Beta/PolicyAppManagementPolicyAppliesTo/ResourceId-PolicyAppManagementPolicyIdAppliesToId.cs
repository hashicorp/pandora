// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyAppManagementPolicyAppliesTo;

internal class PolicyAppManagementPolicyIdAppliesToId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/policies/appManagementPolicies/{appManagementPolicyId}/appliesTo/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.Static("staticAppManagementPolicies", "appManagementPolicies"),
        ResourceIDSegment.UserSpecified("appManagementPolicyId"),
        ResourceIDSegment.Static("staticAppliesTo", "appliesTo"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
