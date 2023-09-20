// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyServicePrincipalCreationPolicyExclude;

internal class PolicyServicePrincipalCreationPolicyIdExcludeId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/policies/servicePrincipalCreationPolicies/{servicePrincipalCreationPolicyId}/excludes/{servicePrincipalCreationConditionSetId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.Static("staticServicePrincipalCreationPolicies", "servicePrincipalCreationPolicies"),
        ResourceIDSegment.UserSpecified("servicePrincipalCreationPolicyId"),
        ResourceIDSegment.Static("staticExcludes", "excludes"),
        ResourceIDSegment.UserSpecified("servicePrincipalCreationConditionSetId")
    };
}
