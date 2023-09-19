// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyCrossTenantAccessPolicyPartnerIdentitySynchronization;

internal class PolicyCrossTenantAccessPolicyPartnerId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/policies/crossTenantAccessPolicy/partners/{crossTenantAccessPolicyConfigurationPartnerTenantId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.Static("staticCrossTenantAccessPolicy", "crossTenantAccessPolicy"),
        ResourceIDSegment.Static("staticPartners", "partners"),
        ResourceIDSegment.UserSpecified("crossTenantAccessPolicyConfigurationPartnerTenantId")
    };
}
