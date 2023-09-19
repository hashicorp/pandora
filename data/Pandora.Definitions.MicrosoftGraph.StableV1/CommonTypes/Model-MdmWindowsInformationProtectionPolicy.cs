// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class MdmWindowsInformationProtectionPolicyModel
{
    [JsonPropertyName("assignments")]
    public List<TargetedManagedAppPolicyAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("azureRightsManagementServicesAllowed")]
    public bool? AzureRightsManagementServicesAllowed { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("dataRecoveryCertificate")]
    public WindowsInformationProtectionDataRecoveryCertificateModel? DataRecoveryCertificate { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enforcementLevel")]
    public MdmWindowsInformationProtectionPolicyEnforcementLevelConstant? EnforcementLevel { get; set; }

    [JsonPropertyName("enterpriseDomain")]
    public string? EnterpriseDomain { get; set; }

    [JsonPropertyName("enterpriseIPRanges")]
    public List<WindowsInformationProtectionIPRangeCollectionModel>? EnterpriseIPRanges { get; set; }

    [JsonPropertyName("enterpriseIPRangesAreAuthoritative")]
    public bool? EnterpriseIPRangesAreAuthoritative { get; set; }

    [JsonPropertyName("enterpriseInternalProxyServers")]
    public List<WindowsInformationProtectionResourceCollectionModel>? EnterpriseInternalProxyServers { get; set; }

    [JsonPropertyName("enterpriseNetworkDomainNames")]
    public List<WindowsInformationProtectionResourceCollectionModel>? EnterpriseNetworkDomainNames { get; set; }

    [JsonPropertyName("enterpriseProtectedDomainNames")]
    public List<WindowsInformationProtectionResourceCollectionModel>? EnterpriseProtectedDomainNames { get; set; }

    [JsonPropertyName("enterpriseProxiedDomains")]
    public List<WindowsInformationProtectionProxiedDomainCollectionModel>? EnterpriseProxiedDomains { get; set; }

    [JsonPropertyName("enterpriseProxyServers")]
    public List<WindowsInformationProtectionResourceCollectionModel>? EnterpriseProxyServers { get; set; }

    [JsonPropertyName("enterpriseProxyServersAreAuthoritative")]
    public bool? EnterpriseProxyServersAreAuthoritative { get; set; }

    [JsonPropertyName("exemptAppLockerFiles")]
    public List<WindowsInformationProtectionAppLockerFileModel>? ExemptAppLockerFiles { get; set; }

    [JsonPropertyName("exemptApps")]
    public List<WindowsInformationProtectionAppModel>? ExemptApps { get; set; }

    [JsonPropertyName("iconsVisible")]
    public bool? IconsVisible { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("indexingEncryptedStoresOrItemsBlocked")]
    public bool? IndexingEncryptedStoresOrItemsBlocked { get; set; }

    [JsonPropertyName("isAssigned")]
    public bool? IsAssigned { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("neutralDomainResources")]
    public List<WindowsInformationProtectionResourceCollectionModel>? NeutralDomainResources { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("protectedAppLockerFiles")]
    public List<WindowsInformationProtectionAppLockerFileModel>? ProtectedAppLockerFiles { get; set; }

    [JsonPropertyName("protectedApps")]
    public List<WindowsInformationProtectionAppModel>? ProtectedApps { get; set; }

    [JsonPropertyName("protectionUnderLockConfigRequired")]
    public bool? ProtectionUnderLockConfigRequired { get; set; }

    [JsonPropertyName("revokeOnUnenrollDisabled")]
    public bool? RevokeOnUnenrollDisabled { get; set; }

    [JsonPropertyName("rightsManagementServicesTemplateId")]
    public string? RightsManagementServicesTemplateId { get; set; }

    [JsonPropertyName("smbAutoEncryptedFileExtensions")]
    public List<WindowsInformationProtectionResourceCollectionModel>? SmbAutoEncryptedFileExtensions { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
