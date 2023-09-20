// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class PolicyRootModel
{
    [JsonPropertyName("activityBasedTimeoutPolicies")]
    public List<ActivityBasedTimeoutPolicyModel>? ActivityBasedTimeoutPolicies { get; set; }

    [JsonPropertyName("adminConsentRequestPolicy")]
    public AdminConsentRequestPolicyModel? AdminConsentRequestPolicy { get; set; }

    [JsonPropertyName("appManagementPolicies")]
    public List<AppManagementPolicyModel>? AppManagementPolicies { get; set; }

    [JsonPropertyName("authenticationFlowsPolicy")]
    public AuthenticationFlowsPolicyModel? AuthenticationFlowsPolicy { get; set; }

    [JsonPropertyName("authenticationMethodsPolicy")]
    public AuthenticationMethodsPolicyModel? AuthenticationMethodsPolicy { get; set; }

    [JsonPropertyName("authenticationStrengthPolicies")]
    public List<AuthenticationStrengthPolicyModel>? AuthenticationStrengthPolicies { get; set; }

    [JsonPropertyName("authorizationPolicy")]
    public AuthorizationPolicyModel? AuthorizationPolicy { get; set; }

    [JsonPropertyName("claimsMappingPolicies")]
    public List<ClaimsMappingPolicyModel>? ClaimsMappingPolicies { get; set; }

    [JsonPropertyName("conditionalAccessPolicies")]
    public List<ConditionalAccessPolicyModel>? ConditionalAccessPolicies { get; set; }

    [JsonPropertyName("crossTenantAccessPolicy")]
    public CrossTenantAccessPolicyModel? CrossTenantAccessPolicy { get; set; }

    [JsonPropertyName("defaultAppManagementPolicy")]
    public TenantAppManagementPolicyModel? DefaultAppManagementPolicy { get; set; }

    [JsonPropertyName("featureRolloutPolicies")]
    public List<FeatureRolloutPolicyModel>? FeatureRolloutPolicies { get; set; }

    [JsonPropertyName("homeRealmDiscoveryPolicies")]
    public List<HomeRealmDiscoveryPolicyModel>? HomeRealmDiscoveryPolicies { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("identitySecurityDefaultsEnforcementPolicy")]
    public IdentitySecurityDefaultsEnforcementPolicyModel? IdentitySecurityDefaultsEnforcementPolicy { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("permissionGrantPolicies")]
    public List<PermissionGrantPolicyModel>? PermissionGrantPolicies { get; set; }

    [JsonPropertyName("roleManagementPolicies")]
    public List<UnifiedRoleManagementPolicyModel>? RoleManagementPolicies { get; set; }

    [JsonPropertyName("roleManagementPolicyAssignments")]
    public List<UnifiedRoleManagementPolicyAssignmentModel>? RoleManagementPolicyAssignments { get; set; }

    [JsonPropertyName("tokenIssuancePolicies")]
    public List<TokenIssuancePolicyModel>? TokenIssuancePolicies { get; set; }

    [JsonPropertyName("tokenLifetimePolicies")]
    public List<TokenLifetimePolicyModel>? TokenLifetimePolicies { get; set; }
}
