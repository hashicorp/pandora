// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ApplicationModel
{
    [JsonPropertyName("addIns")]
    public List<AddInModel>? AddIns { get; set; }

    [JsonPropertyName("api")]
    public ApiApplicationModel? Api { get; set; }

    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    [JsonPropertyName("appManagementPolicies")]
    public List<AppManagementPolicyModel>? AppManagementPolicies { get; set; }

    [JsonPropertyName("appRoles")]
    public List<AppRoleModel>? AppRoles { get; set; }

    [JsonPropertyName("applicationTemplateId")]
    public string? ApplicationTemplateId { get; set; }

    [JsonPropertyName("certification")]
    public CertificationModel? Certification { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("createdOnBehalfOf")]
    public DirectoryObjectModel? CreatedOnBehalfOf { get; set; }

    [JsonPropertyName("defaultRedirectUri")]
    public string? DefaultRedirectUri { get; set; }

    [JsonPropertyName("deletedDateTime")]
    public DateTime? DeletedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("disabledByMicrosoftStatus")]
    public string? DisabledByMicrosoftStatus { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("extensionProperties")]
    public List<ExtensionPropertyModel>? ExtensionProperties { get; set; }

    [JsonPropertyName("federatedIdentityCredentials")]
    public List<FederatedIdentityCredentialModel>? FederatedIdentityCredentials { get; set; }

    [JsonPropertyName("groupMembershipClaims")]
    public string? GroupMembershipClaims { get; set; }

    [JsonPropertyName("homeRealmDiscoveryPolicies")]
    public List<HomeRealmDiscoveryPolicyModel>? HomeRealmDiscoveryPolicies { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("identifierUris")]
    public List<string>? IdentifierUris { get; set; }

    [JsonPropertyName("info")]
    public InformationalUrlModel? Info { get; set; }

    [JsonPropertyName("isDeviceOnlyAuthSupported")]
    public bool? IsDeviceOnlyAuthSupported { get; set; }

    [JsonPropertyName("isFallbackPublicClient")]
    public bool? IsFallbackPublicClient { get; set; }

    [JsonPropertyName("keyCredentials")]
    public List<KeyCredentialModel>? KeyCredentials { get; set; }

    [JsonPropertyName("logo")]
    public string? Logo { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("oauth2RequirePostResponse")]
    public bool? Oauth2RequirePostResponse { get; set; }

    [JsonPropertyName("optionalClaims")]
    public OptionalClaimsModel? OptionalClaims { get; set; }

    [JsonPropertyName("owners")]
    public List<DirectoryObjectModel>? Owners { get; set; }

    [JsonPropertyName("parentalControlSettings")]
    public ParentalControlSettingsModel? ParentalControlSettings { get; set; }

    [JsonPropertyName("passwordCredentials")]
    public List<PasswordCredentialModel>? PasswordCredentials { get; set; }

    [JsonPropertyName("publicClient")]
    public PublicClientApplicationModel? PublicClient { get; set; }

    [JsonPropertyName("publisherDomain")]
    public string? PublisherDomain { get; set; }

    [JsonPropertyName("requestSignatureVerification")]
    public RequestSignatureVerificationModel? RequestSignatureVerification { get; set; }

    [JsonPropertyName("requiredResourceAccess")]
    public List<RequiredResourceAccessModel>? RequiredResourceAccess { get; set; }

    [JsonPropertyName("samlMetadataUrl")]
    public string? SamlMetadataUrl { get; set; }

    [JsonPropertyName("serviceManagementReference")]
    public string? ServiceManagementReference { get; set; }

    [JsonPropertyName("servicePrincipalLockConfiguration")]
    public ServicePrincipalLockConfigurationModel? ServicePrincipalLockConfiguration { get; set; }

    [JsonPropertyName("signInAudience")]
    public string? SignInAudience { get; set; }

    [JsonPropertyName("spa")]
    public SpaApplicationModel? Spa { get; set; }

    [JsonPropertyName("synchronization")]
    public SynchronizationModel? Synchronization { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("tokenEncryptionKeyId")]
    public string? TokenEncryptionKeyId { get; set; }

    [JsonPropertyName("tokenIssuancePolicies")]
    public List<TokenIssuancePolicyModel>? TokenIssuancePolicies { get; set; }

    [JsonPropertyName("tokenLifetimePolicies")]
    public List<TokenLifetimePolicyModel>? TokenLifetimePolicies { get; set; }

    [JsonPropertyName("verifiedPublisher")]
    public VerifiedPublisherModel? VerifiedPublisher { get; set; }

    [JsonPropertyName("web")]
    public WebApplicationModel? Web { get; set; }
}
