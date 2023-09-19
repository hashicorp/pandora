// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Policies.StableV1;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "StableV1";
    public bool Preview => false;
    public Source Source => Source.MicrosoftGraphMetadata;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Policy.Definition(),
        new PolicyActivityBasedTimeoutPolicy.Definition(),
        new PolicyActivityBasedTimeoutPolicyAppliesTo.Definition(),
        new PolicyAdminConsentRequestPolicy.Definition(),
        new PolicyAppManagementPolicy.Definition(),
        new PolicyAppManagementPolicyAppliesTo.Definition(),
        new PolicyAuthenticationFlowsPolicy.Definition(),
        new PolicyAuthenticationMethodsPolicy.Definition(),
        new PolicyAuthenticationMethodsPolicyAuthenticationMethodConfiguration.Definition(),
        new PolicyAuthenticationStrengthPolicy.Definition(),
        new PolicyAuthenticationStrengthPolicyCombinationConfiguration.Definition(),
        new PolicyAuthorizationPolicy.Definition(),
        new PolicyClaimsMappingPolicy.Definition(),
        new PolicyClaimsMappingPolicyAppliesTo.Definition(),
        new PolicyConditionalAccessPolicy.Definition(),
        new PolicyCrossTenantAccessPolicy.Definition(),
        new PolicyCrossTenantAccessPolicyDefault.Definition(),
        new PolicyCrossTenantAccessPolicyPartner.Definition(),
        new PolicyCrossTenantAccessPolicyPartnerIdentitySynchronization.Definition(),
        new PolicyDefaultAppManagementPolicy.Definition(),
        new PolicyFeatureRolloutPolicy.Definition(),
        new PolicyFeatureRolloutPolicyAppliesTo.Definition(),
        new PolicyHomeRealmDiscoveryPolicy.Definition(),
        new PolicyHomeRealmDiscoveryPolicyAppliesTo.Definition(),
        new PolicyIdentitySecurityDefaultsEnforcementPolicy.Definition(),
        new PolicyPermissionGrantPolicy.Definition(),
        new PolicyPermissionGrantPolicyExclude.Definition(),
        new PolicyPermissionGrantPolicyInclude.Definition(),
        new PolicyRoleManagementPolicy.Definition(),
        new PolicyRoleManagementPolicyAssignment.Definition(),
        new PolicyRoleManagementPolicyAssignmentPolicy.Definition(),
        new PolicyRoleManagementPolicyEffectiveRule.Definition(),
        new PolicyRoleManagementPolicyRule.Definition(),
        new PolicyTokenIssuancePolicy.Definition(),
        new PolicyTokenIssuancePolicyAppliesTo.Definition(),
        new PolicyTokenLifetimePolicy.Definition(),
        new PolicyTokenLifetimePolicyAppliesTo.Definition()
    };
}
