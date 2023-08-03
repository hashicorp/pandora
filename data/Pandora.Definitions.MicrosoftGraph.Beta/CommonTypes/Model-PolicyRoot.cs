// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PolicyRootModel
{
    [JsonPropertyName("accessReviewPolicy")]
    public AccessReviewPolicyModel? AccessReviewPolicy { get; set; }

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
    public List<AuthorizationPolicyModel>? AuthorizationPolicy { get; set; }

    [JsonPropertyName("b2cAuthenticationMethodsPolicy")]
    public B2cAuthenticationMethodsPolicyModel? B2cAuthenticationMethodsPolicy { get; set; }

    [JsonPropertyName("claimsMappingPolicies")]
    public List<ClaimsMappingPolicyModel>? ClaimsMappingPolicies { get; set; }

    [JsonPropertyName("conditionalAccessPolicies")]
    public List<ConditionalAccessPolicyModel>? ConditionalAccessPolicies { get; set; }

    [JsonPropertyName("crossTenantAccessPolicy")]
    public CrossTenantAccessPolicyModel? CrossTenantAccessPolicy { get; set; }

    [JsonPropertyName("defaultAppManagementPolicy")]
    public TenantAppManagementPolicyModel? DefaultAppManagementPolicy { get; set; }

    [JsonPropertyName("deviceRegistrationPolicy")]
    public DeviceRegistrationPolicyModel? DeviceRegistrationPolicy { get; set; }

    [JsonPropertyName("directoryRoleAccessReviewPolicy")]
    public DirectoryRoleAccessReviewPolicyModel? DirectoryRoleAccessReviewPolicy { get; set; }

    [JsonPropertyName("externalIdentitiesPolicy")]
    public ExternalIdentitiesPolicyModel? ExternalIdentitiesPolicy { get; set; }

    [JsonPropertyName("featureRolloutPolicies")]
    public List<FeatureRolloutPolicyModel>? FeatureRolloutPolicies { get; set; }

    [JsonPropertyName("homeRealmDiscoveryPolicies")]
    public List<HomeRealmDiscoveryPolicyModel>? HomeRealmDiscoveryPolicies { get; set; }

    [JsonPropertyName("identitySecurityDefaultsEnforcementPolicy")]
    public IdentitySecurityDefaultsEnforcementPolicyModel? IdentitySecurityDefaultsEnforcementPolicy { get; set; }

    [JsonPropertyName("mobileAppManagementPolicies")]
    public List<MobilityManagementPolicyModel>? MobileAppManagementPolicies { get; set; }

    [JsonPropertyName("mobileDeviceManagementPolicies")]
    public List<MobilityManagementPolicyModel>? MobileDeviceManagementPolicies { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("permissionGrantPolicies")]
    public List<PermissionGrantPolicyModel>? PermissionGrantPolicies { get; set; }

    [JsonPropertyName("roleManagementPolicies")]
    public List<UnifiedRoleManagementPolicyModel>? RoleManagementPolicies { get; set; }

    [JsonPropertyName("roleManagementPolicyAssignments")]
    public List<UnifiedRoleManagementPolicyAssignmentModel>? RoleManagementPolicyAssignments { get; set; }

    [JsonPropertyName("servicePrincipalCreationPolicies")]
    public List<ServicePrincipalCreationPolicyModel>? ServicePrincipalCreationPolicies { get; set; }

    [JsonPropertyName("tokenIssuancePolicies")]
    public List<TokenIssuancePolicyModel>? TokenIssuancePolicies { get; set; }

    [JsonPropertyName("tokenLifetimePolicies")]
    public List<TokenLifetimePolicyModel>? TokenLifetimePolicies { get; set; }
}
