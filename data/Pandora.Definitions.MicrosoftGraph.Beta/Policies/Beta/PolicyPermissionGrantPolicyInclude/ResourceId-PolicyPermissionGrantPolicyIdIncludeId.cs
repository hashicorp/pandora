// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyPermissionGrantPolicyInclude;

internal class PolicyPermissionGrantPolicyIdIncludeId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/policies/permissionGrantPolicies/{permissionGrantPolicyId}/includes/{permissionGrantConditionSetId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.Static("staticPermissionGrantPolicies", "permissionGrantPolicies"),
        ResourceIDSegment.UserSpecified("permissionGrantPolicyId"),
        ResourceIDSegment.Static("staticIncludes", "includes"),
        ResourceIDSegment.UserSpecified("permissionGrantConditionSetId")
    };
}
