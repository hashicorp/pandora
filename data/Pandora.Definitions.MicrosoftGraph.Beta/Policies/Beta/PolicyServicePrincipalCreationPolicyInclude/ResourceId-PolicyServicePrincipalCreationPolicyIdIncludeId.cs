// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyServicePrincipalCreationPolicyInclude;

internal class PolicyServicePrincipalCreationPolicyIdIncludeId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/policies/servicePrincipalCreationPolicies/{servicePrincipalCreationPolicyId}/includes/{servicePrincipalCreationConditionSetId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.Static("staticServicePrincipalCreationPolicies", "servicePrincipalCreationPolicies"),
        ResourceIDSegment.UserSpecified("servicePrincipalCreationPolicyId"),
        ResourceIDSegment.Static("staticIncludes", "includes"),
        ResourceIDSegment.UserSpecified("servicePrincipalCreationConditionSetId")
    };
}
