// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MacOSVpnConfigurationModel
{
    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("associatedDomains")]
    public List<string>? AssociatedDomains { get; set; }

    [JsonPropertyName("authenticationMethod")]
    public VpnAuthenticationMethodConstant? AuthenticationMethod { get; set; }

    [JsonPropertyName("connectionName")]
    public string? ConnectionName { get; set; }

    [JsonPropertyName("connectionType")]
    public AppleVpnConnectionTypeConstant? ConnectionType { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("customData")]
    public List<KeyValueModel>? CustomData { get; set; }

    [JsonPropertyName("customKeyValueData")]
    public List<KeyValuePairModel>? CustomKeyValueData { get; set; }

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

    [JsonPropertyName("disableOnDemandUserOverride")]
    public bool? DisableOnDemandUserOverride { get; set; }

    [JsonPropertyName("disconnectOnIdle")]
    public bool? DisconnectOnIdle { get; set; }

    [JsonPropertyName("disconnectOnIdleTimerInSeconds")]
    public int? DisconnectOnIdleTimerInSeconds { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enablePerApp")]
    public bool? EnablePerApp { get; set; }

    [JsonPropertyName("enableSplitTunneling")]
    public bool? EnableSplitTunneling { get; set; }

    [JsonPropertyName("excludedDomains")]
    public List<string>? ExcludedDomains { get; set; }

    [JsonPropertyName("groupAssignments")]
    public List<DeviceConfigurationGroupAssignmentModel>? GroupAssignments { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    [JsonPropertyName("identityCertificate")]
    public MacOSCertificateProfileBaseModel? IdentityCertificate { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("loginGroupOrDomain")]
    public string? LoginGroupOrDomain { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onDemandRules")]
    public List<VpnOnDemandRuleModel>? OnDemandRules { get; set; }

    [JsonPropertyName("optInToDeviceIdSharing")]
    public bool? OptInToDeviceIdSharing { get; set; }

    [JsonPropertyName("providerType")]
    public VpnProviderTypeConstant? ProviderType { get; set; }

    [JsonPropertyName("proxyServer")]
    public VpnProxyServerModel? ProxyServer { get; set; }

    [JsonPropertyName("realm")]
    public string? Realm { get; set; }

    [JsonPropertyName("role")]
    public string? Role { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("safariDomains")]
    public List<string>? SafariDomains { get; set; }

    [JsonPropertyName("server")]
    public VpnServerModel? Server { get; set; }

    [JsonPropertyName("supportsScopeTags")]
    public bool? SupportsScopeTags { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
