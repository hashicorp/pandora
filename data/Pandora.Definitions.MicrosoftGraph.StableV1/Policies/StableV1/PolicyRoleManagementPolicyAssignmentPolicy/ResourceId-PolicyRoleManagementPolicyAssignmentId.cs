// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Policies.StableV1.PolicyRoleManagementPolicyAssignmentPolicy;

internal class PolicyRoleManagementPolicyAssignmentId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/policies/roleManagementPolicyAssignments/{unifiedRoleManagementPolicyAssignmentId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.Static("staticRoleManagementPolicyAssignments", "roleManagementPolicyAssignments"),
        ResourceIDSegment.UserSpecified("unifiedRoleManagementPolicyAssignmentId")
    };
}
