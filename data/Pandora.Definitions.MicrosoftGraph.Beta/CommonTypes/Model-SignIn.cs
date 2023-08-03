// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SignInModel
{
    [JsonPropertyName("appDisplayName")]
    public string? AppDisplayName { get; set; }

    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    [JsonPropertyName("appliedConditionalAccessPolicies")]
    public List<AppliedConditionalAccessPolicyModel>? AppliedConditionalAccessPolicies { get; set; }

    [JsonPropertyName("appliedEventListeners")]
    public List<AppliedAuthenticationEventListenerModel>? AppliedEventListeners { get; set; }

    [JsonPropertyName("authenticationAppDeviceDetails")]
    public AuthenticationAppDeviceDetailsModel? AuthenticationAppDeviceDetails { get; set; }

    [JsonPropertyName("authenticationAppPolicyEvaluationDetails")]
    public List<AuthenticationAppPolicyDetailsModel>? AuthenticationAppPolicyEvaluationDetails { get; set; }

    [JsonPropertyName("authenticationContextClassReferences")]
    public List<AuthenticationContextModel>? AuthenticationContextClassReferences { get; set; }

    [JsonPropertyName("authenticationDetails")]
    public List<AuthenticationDetailModel>? AuthenticationDetails { get; set; }

    [JsonPropertyName("authenticationMethodsUsed")]
    public List<string>? AuthenticationMethodsUsed { get; set; }

    [JsonPropertyName("authenticationProcessingDetails")]
    public List<KeyValueModel>? AuthenticationProcessingDetails { get; set; }

    [JsonPropertyName("authenticationProtocol")]
    public ProtocolTypeConstant? AuthenticationProtocol { get; set; }

    [JsonPropertyName("authenticationRequirement")]
    public string? AuthenticationRequirement { get; set; }

    [JsonPropertyName("authenticationRequirementPolicies")]
    public List<AuthenticationRequirementPolicyModel>? AuthenticationRequirementPolicies { get; set; }

    [JsonPropertyName("autonomousSystemNumber")]
    public int? AutonomousSystemNumber { get; set; }

    [JsonPropertyName("azureResourceId")]
    public string? AzureResourceId { get; set; }

    [JsonPropertyName("clientAppUsed")]
    public string? ClientAppUsed { get; set; }

    [JsonPropertyName("clientCredentialType")]
    public ClientCredentialTypeConstant? ClientCredentialType { get; set; }

    [JsonPropertyName("conditionalAccessStatus")]
    public ConditionalAccessStatusConstant? ConditionalAccessStatus { get; set; }

    [JsonPropertyName("correlationId")]
    public string? CorrelationId { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("crossTenantAccessType")]
    public SignInAccessTypeConstant? CrossTenantAccessType { get; set; }

    [JsonPropertyName("deviceDetail")]
    public DeviceDetailModel? DeviceDetail { get; set; }

    [JsonPropertyName("federatedCredentialId")]
    public string? FederatedCredentialId { get; set; }

    [JsonPropertyName("flaggedForReview")]
    public bool? FlaggedForReview { get; set; }

    [JsonPropertyName("homeTenantId")]
    public string? HomeTenantId { get; set; }

    [JsonPropertyName("homeTenantName")]
    public string? HomeTenantName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("incomingTokenType")]
    public IncomingTokenTypeConstant? IncomingTokenType { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }

    [JsonPropertyName("ipAddressFromResourceProvider")]
    public string? IpAddressFromResourceProvider { get; set; }

    [JsonPropertyName("isInteractive")]
    public bool? IsInteractive { get; set; }

    [JsonPropertyName("isTenantRestricted")]
    public bool? IsTenantRestricted { get; set; }

    [JsonPropertyName("location")]
    public SignInLocationModel? Location { get; set; }

    [JsonPropertyName("managedServiceIdentity")]
    public ManagedIdentityModel? ManagedServiceIdentity { get; set; }

    [JsonPropertyName("mfaDetail")]
    public MfaDetailModel? MfaDetail { get; set; }

    [JsonPropertyName("networkLocationDetails")]
    public List<NetworkLocationDetailModel>? NetworkLocationDetails { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("originalRequestId")]
    public string? OriginalRequestId { get; set; }

    [JsonPropertyName("privateLinkDetails")]
    public PrivateLinkDetailsModel? PrivateLinkDetails { get; set; }

    [JsonPropertyName("processingTimeInMilliseconds")]
    public int? ProcessingTimeInMilliseconds { get; set; }

    [JsonPropertyName("resourceDisplayName")]
    public string? ResourceDisplayName { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("resourceServicePrincipalId")]
    public string? ResourceServicePrincipalId { get; set; }

    [JsonPropertyName("resourceTenantId")]
    public string? ResourceTenantId { get; set; }

    [JsonPropertyName("riskDetail")]
    public RiskDetailConstant? RiskDetail { get; set; }

    [JsonPropertyName("riskEventTypes_v2")]
    public List<string>? RiskEventTypesv2 { get; set; }

    [JsonPropertyName("riskLevelAggregated")]
    public RiskLevelConstant? RiskLevelAggregated { get; set; }

    [JsonPropertyName("riskLevelDuringSignIn")]
    public RiskLevelConstant? RiskLevelDuringSignIn { get; set; }

    [JsonPropertyName("riskState")]
    public RiskStateConstant? RiskState { get; set; }

    [JsonPropertyName("servicePrincipalCredentialKeyId")]
    public string? ServicePrincipalCredentialKeyId { get; set; }

    [JsonPropertyName("servicePrincipalCredentialThumbprint")]
    public string? ServicePrincipalCredentialThumbprint { get; set; }

    [JsonPropertyName("servicePrincipalId")]
    public string? ServicePrincipalId { get; set; }

    [JsonPropertyName("servicePrincipalName")]
    public string? ServicePrincipalName { get; set; }

    [JsonPropertyName("sessionLifetimePolicies")]
    public List<SessionLifetimePolicyModel>? SessionLifetimePolicies { get; set; }

    [JsonPropertyName("signInEventTypes")]
    public List<string>? SignInEventTypes { get; set; }

    [JsonPropertyName("signInIdentifier")]
    public string? SignInIdentifier { get; set; }

    [JsonPropertyName("signInIdentifierType")]
    public SignInIdentifierTypeConstant? SignInIdentifierType { get; set; }

    [JsonPropertyName("status")]
    public SignInStatusModel? Status { get; set; }

    [JsonPropertyName("tokenIssuerName")]
    public string? TokenIssuerName { get; set; }

    [JsonPropertyName("tokenIssuerType")]
    public TokenIssuerTypeConstant? TokenIssuerType { get; set; }

    [JsonPropertyName("uniqueTokenIdentifier")]
    public string? UniqueTokenIdentifier { get; set; }

    [JsonPropertyName("userAgent")]
    public string? UserAgent { get; set; }

    [JsonPropertyName("userDisplayName")]
    public string? UserDisplayName { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }

    [JsonPropertyName("userType")]
    public SignInUserTypeConstant? UserType { get; set; }
}
