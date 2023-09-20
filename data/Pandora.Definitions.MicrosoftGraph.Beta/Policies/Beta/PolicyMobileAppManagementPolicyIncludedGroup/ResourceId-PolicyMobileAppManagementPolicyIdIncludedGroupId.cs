// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyMobileAppManagementPolicyIncludedGroup;

internal class PolicyMobileAppManagementPolicyIdIncludedGroupId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/policies/mobileAppManagementPolicies/{mobilityManagementPolicyId}/includedGroups/{groupId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.Static("staticMobileAppManagementPolicies", "mobileAppManagementPolicies"),
        ResourceIDSegment.UserSpecified("mobilityManagementPolicyId"),
        ResourceIDSegment.Static("staticIncludedGroups", "includedGroups"),
        ResourceIDSegment.UserSpecified("groupId")
    };
}
