// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ServicePrincipalModel
{
    [JsonPropertyName("accountEnabled")]
    public bool? AccountEnabled { get; set; }

    [JsonPropertyName("addIns")]
    public List<AddInModel>? AddIns { get; set; }

    [JsonPropertyName("alternativeNames")]
    public List<string>? AlternativeNames { get; set; }

    [JsonPropertyName("appDescription")]
    public string? AppDescription { get; set; }

    [JsonPropertyName("appDisplayName")]
    public string? AppDisplayName { get; set; }

    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    [JsonPropertyName("appManagementPolicies")]
    public List<AppManagementPolicyModel>? AppManagementPolicies { get; set; }

    [JsonPropertyName("appOwnerOrganizationId")]
    public string? AppOwnerOrganizationId { get; set; }

    [JsonPropertyName("appRoleAssignedTo")]
    public List<AppRoleAssignmentModel>? AppRoleAssignedTo { get; set; }

    [JsonPropertyName("appRoleAssignmentRequired")]
    public bool? AppRoleAssignmentRequired { get; set; }

    [JsonPropertyName("appRoleAssignments")]
    public List<AppRoleAssignmentModel>? AppRoleAssignments { get; set; }

    [JsonPropertyName("appRoles")]
    public List<AppRoleModel>? AppRoles { get; set; }

    [JsonPropertyName("applicationTemplateId")]
    public string? ApplicationTemplateId { get; set; }

    [JsonPropertyName("claimsMappingPolicies")]
    public List<ClaimsMappingPolicyModel>? ClaimsMappingPolicies { get; set; }

    [JsonPropertyName("createdObjects")]
    public List<DirectoryObjectModel>? CreatedObjects { get; set; }

    [JsonPropertyName("customSecurityAttributes")]
    public CustomSecurityAttributeValueModel? CustomSecurityAttributes { get; set; }

    [JsonPropertyName("delegatedPermissionClassifications")]
    public List<DelegatedPermissionClassificationModel>? DelegatedPermissionClassifications { get; set; }

    [JsonPropertyName("deletedDateTime")]
    public DateTime? DeletedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("disabledByMicrosoftStatus")]
    public string? DisabledByMicrosoftStatus { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("endpoints")]
    public List<EndpointModel>? Endpoints { get; set; }

    [JsonPropertyName("errorUrl")]
    public string? ErrorUrl { get; set; }

    [JsonPropertyName("federatedIdentityCredentials")]
    public List<FederatedIdentityCredentialModel>? FederatedIdentityCredentials { get; set; }

    [JsonPropertyName("homeRealmDiscoveryPolicies")]
    public List<HomeRealmDiscoveryPolicyModel>? HomeRealmDiscoveryPolicies { get; set; }

    [JsonPropertyName("homepage")]
    public string? Homepage { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("info")]
    public InformationalUrlModel? Info { get; set; }

    [JsonPropertyName("keyCredentials")]
    public List<KeyCredentialModel>? KeyCredentials { get; set; }

    [JsonPropertyName("licenseDetails")]
    public List<LicenseDetailsModel>? LicenseDetails { get; set; }

    [JsonPropertyName("loginUrl")]
    public string? LoginUrl { get; set; }

    [JsonPropertyName("logoutUrl")]
    public string? LogoutUrl { get; set; }

    [JsonPropertyName("memberOf")]
    public List<DirectoryObjectModel>? MemberOf { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("notificationEmailAddresses")]
    public List<string>? NotificationEmailAddresses { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("oauth2PermissionGrants")]
    public List<OAuth2PermissionGrantModel>? Oauth2PermissionGrants { get; set; }

    [JsonPropertyName("ownedObjects")]
    public List<DirectoryObjectModel>? OwnedObjects { get; set; }

    [JsonPropertyName("owners")]
    public List<DirectoryObjectModel>? Owners { get; set; }

    [JsonPropertyName("passwordCredentials")]
    public List<PasswordCredentialModel>? PasswordCredentials { get; set; }

    [JsonPropertyName("passwordSingleSignOnSettings")]
    public PasswordSingleSignOnSettingsModel? PasswordSingleSignOnSettings { get; set; }

    [JsonPropertyName("preferredSingleSignOnMode")]
    public string? PreferredSingleSignOnMode { get; set; }

    [JsonPropertyName("preferredTokenSigningKeyEndDateTime")]
    public DateTime? PreferredTokenSigningKeyEndDateTime { get; set; }

    [JsonPropertyName("preferredTokenSigningKeyThumbprint")]
    public string? PreferredTokenSigningKeyThumbprint { get; set; }

    [JsonPropertyName("publishedPermissionScopes")]
    public List<PermissionScopeModel>? PublishedPermissionScopes { get; set; }

    [JsonPropertyName("publisherName")]
    public string? PublisherName { get; set; }

    [JsonPropertyName("remoteDesktopSecurityConfiguration")]
    public RemoteDesktopSecurityConfigurationModel? RemoteDesktopSecurityConfiguration { get; set; }

    [JsonPropertyName("replyUrls")]
    public List<string>? ReplyUrls { get; set; }

    [JsonPropertyName("samlMetadataUrl")]
    public string? SamlMetadataUrl { get; set; }

    [JsonPropertyName("samlSingleSignOnSettings")]
    public SamlSingleSignOnSettingsModel? SamlSingleSignOnSettings { get; set; }

    [JsonPropertyName("servicePrincipalNames")]
    public List<string>? ServicePrincipalNames { get; set; }

    [JsonPropertyName("servicePrincipalType")]
    public string? ServicePrincipalType { get; set; }

    [JsonPropertyName("signInAudience")]
    public string? SignInAudience { get; set; }

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

    [JsonPropertyName("transitiveMemberOf")]
    public List<DirectoryObjectModel>? TransitiveMemberOf { get; set; }

    [JsonPropertyName("verifiedPublisher")]
    public VerifiedPublisherModel? VerifiedPublisher { get; set; }
}
