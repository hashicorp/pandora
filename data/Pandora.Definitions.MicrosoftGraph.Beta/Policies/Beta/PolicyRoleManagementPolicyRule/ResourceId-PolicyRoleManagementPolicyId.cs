// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyRoleManagementPolicyRule;

internal class PolicyRoleManagementPolicyId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/policies/roleManagementPolicies/{unifiedRoleManagementPolicyId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.Static("staticRoleManagementPolicies", "roleManagementPolicies"),
        ResourceIDSegment.UserSpecified("unifiedRoleManagementPolicyId")
    };
}
