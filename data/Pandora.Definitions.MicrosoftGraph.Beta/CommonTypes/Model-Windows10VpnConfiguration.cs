// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Windows10VpnConfigurationModel
{
    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("associatedApps")]
    public List<Windows10AssociatedAppsModel>? AssociatedApps { get; set; }

    [JsonPropertyName("authenticationMethod")]
    public Windows10VpnConfigurationAuthenticationMethodConstant? AuthenticationMethod { get; set; }

    [JsonPropertyName("connectionName")]
    public string? ConnectionName { get; set; }

    [JsonPropertyName("connectionType")]
    public Windows10VpnConfigurationConnectionTypeConstant? ConnectionType { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("cryptographySuite")]
    public CryptographySuiteModel? CryptographySuite { get; set; }

    [JsonPropertyName("customXml")]
    public string? CustomXml { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceManagementApplicabilityRuleDeviceMode")]
    public DeviceManagementApplicabilityRuleDeviceModeModel? DeviceManagementApplicabilityRuleDeviceMode { get; set; }

    [JsonPropertyName("deviceManagementApplicabilityRuleOsEdition")]
    public DeviceManagementApplicabilityRuleOsEditionModel? DeviceManagementApplicabilityRuleOsEdition { get; set; }

    [JsonPropertyName("deviceManagementApplicabilityRuleOsVersion")]
    public DeviceManagementApplicabilityRuleOsVersionModel? DeviceManagementApplicabilityRuleOsVersion { get; set; }

    [JsonPropertyName("deviceSettingStateSummaries")]
    public List<SettingStateDeviceSummaryModel>? DeviceSettingStateSummaries { get; set; }

    [JsonPropertyName("deviceStatusOverview")]
    public DeviceConfigurationDeviceOverviewModel? DeviceStatusOverview { get; set; }

    [JsonPropertyName("deviceStatuses")]
    public List<DeviceConfigurationDeviceStatusModel>? DeviceStatuses { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("dnsRules")]
    public List<VpnDnsRuleModel>? DnsRules { get; set; }

    [JsonPropertyName("dnsSuffixes")]
    public List<string>? DnsSuffixes { get; set; }

    [JsonPropertyName("eapXml")]
    public string? EapXml { get; set; }

    [JsonPropertyName("enableAlwaysOn")]
    public bool? EnableAlwaysOn { get; set; }

    [JsonPropertyName("enableConditionalAccess")]
    public bool? EnableConditionalAccess { get; set; }

    [JsonPropertyName("enableDeviceTunnel")]
    public bool? EnableDeviceTunnel { get; set; }

    [JsonPropertyName("enableDnsRegistration")]
    public bool? EnableDnsRegistration { get; set; }

    [JsonPropertyName("enableSingleSignOnWithAlternateCertificate")]
    public bool? EnableSingleSignOnWithAlternateCertificate { get; set; }

    [JsonPropertyName("enableSplitTunneling")]
    public bool? EnableSplitTunneling { get; set; }

    [JsonPropertyName("groupAssignments")]
    public List<DeviceConfigurationGroupAssignmentModel>? GroupAssignments { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("identityCertificate")]
    public WindowsCertificateProfileBaseModel? IdentityCertificate { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("microsoftTunnelSiteId")]
    public string? MicrosoftTunnelSiteId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onlyAssociatedAppsCanUseConnection")]
    public bool? OnlyAssociatedAppsCanUseConnection { get; set; }

    [JsonPropertyName("profileTarget")]
    public Windows10VpnConfigurationProfileTargetConstant? ProfileTarget { get; set; }

    [JsonPropertyName("proxyServer")]
    public Windows10VpnProxyServerModel? ProxyServer { get; set; }

    [JsonPropertyName("rememberUserCredentials")]
    public bool? RememberUserCredentials { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("routes")]
    public List<VpnRouteModel>? Routes { get; set; }

    [JsonPropertyName("servers")]
    public List<VpnServerModel>? Servers { get; set; }

    [JsonPropertyName("singleSignOnEku")]
    public ExtendedKeyUsageModel? SingleSignOnEku { get; set; }

    [JsonPropertyName("singleSignOnIssuerHash")]
    public string? SingleSignOnIssuerHash { get; set; }

    [JsonPropertyName("supportsScopeTags")]
    public bool? SupportsScopeTags { get; set; }

    [JsonPropertyName("trafficRules")]
    public List<VpnTrafficRuleModel>? TrafficRules { get; set; }

    [JsonPropertyName("trustedNetworkDomains")]
    public List<string>? TrustedNetworkDomains { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("windowsInformationProtectionDomain")]
    public string? WindowsInformationProtectionDomain { get; set; }
}
