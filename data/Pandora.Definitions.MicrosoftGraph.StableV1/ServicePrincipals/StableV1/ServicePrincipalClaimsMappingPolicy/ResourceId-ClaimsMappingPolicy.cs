// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.ServicePrincipals.StableV1.ServicePrincipalClaimsMappingPolicy;

internal class ClaimsMappingPolicyId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/servicePrincipals/{servicePrincipalId}/claimsMappingPolicies/{claimsMappingPolicyId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticServicePrincipals", "servicePrincipals"),
        ResourceIDSegment.UserSpecified("servicePrincipalId"),
        ResourceIDSegment.Static("staticClaimsMappingPolicies", "claimsMappingPolicies"),
        ResourceIDSegment.UserSpecified("claimsMappingPolicyId")
    };
}
