// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Policies.StableV1.PolicyRoleManagementPolicyRule;

internal class PolicyRoleManagementPolicyIdRuleId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/policies/roleManagementPolicies/{unifiedRoleManagementPolicyId}/rules/{unifiedRoleManagementPolicyRuleId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.Static("staticRoleManagementPolicies", "roleManagementPolicies"),
        ResourceIDSegment.UserSpecified("unifiedRoleManagementPolicyId"),
        ResourceIDSegment.Static("staticRules", "rules"),
        ResourceIDSegment.UserSpecified("unifiedRoleManagementPolicyRuleId")
    };
}
