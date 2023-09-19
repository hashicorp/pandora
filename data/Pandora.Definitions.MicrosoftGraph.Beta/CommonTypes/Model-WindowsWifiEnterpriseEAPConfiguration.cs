// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsWifiEnterpriseEAPConfigurationModel
{
    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("authenticationMethod")]
    public WindowsWifiEnterpriseEAPConfigurationAuthenticationMethodConstant? AuthenticationMethod { get; set; }

    [JsonPropertyName("authenticationPeriodInSeconds")]
    public int? AuthenticationPeriodInSeconds { get; set; }

    [JsonPropertyName("authenticationRetryDelayPeriodInSeconds")]
    public int? AuthenticationRetryDelayPeriodInSeconds { get; set; }

    [JsonPropertyName("authenticationType")]
    public WindowsWifiEnterpriseEAPConfigurationAuthenticationTypeConstant? AuthenticationType { get; set; }

    [JsonPropertyName("cacheCredentials")]
    public bool? CacheCredentials { get; set; }

    [JsonPropertyName("connectAutomatically")]
    public bool? ConnectAutomatically { get; set; }

    [JsonPropertyName("connectToPreferredNetwork")]
    public bool? ConnectToPreferredNetwork { get; set; }

    [JsonPropertyName("connectWhenNetworkNameIsHidden")]
    public bool? ConnectWhenNetworkNameIsHidden { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

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

    [JsonPropertyName("disableUserPromptForServerValidation")]
    public bool? DisableUserPromptForServerValidation { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("eapType")]
    public WindowsWifiEnterpriseEAPConfigurationEapTypeConstant? EapType { get; set; }

    [JsonPropertyName("eapolStartPeriodInSeconds")]
    public int? EapolStartPeriodInSeconds { get; set; }

    [JsonPropertyName("enablePairwiseMasterKeyCaching")]
    public bool? EnablePairwiseMasterKeyCaching { get; set; }

    [JsonPropertyName("enablePreAuthentication")]
    public bool? EnablePreAuthentication { get; set; }

    [JsonPropertyName("forceFIPSCompliance")]
    public bool? ForceFIPSCompliance { get; set; }

    [JsonPropertyName("groupAssignments")]
    public List<DeviceConfigurationGroupAssignmentModel>? GroupAssignments { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("identityCertificateForClientAuthentication")]
    public WindowsCertificateProfileBaseModel? IdentityCertificateForClientAuthentication { get; set; }

    [JsonPropertyName("innerAuthenticationProtocolForEAPTTLS")]
    public WindowsWifiEnterpriseEAPConfigurationInnerAuthenticationProtocolForEAPTTLSConstant? InnerAuthenticationProtocolForEAPTTLS { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("maximumAuthenticationFailures")]
    public int? MaximumAuthenticationFailures { get; set; }

    [JsonPropertyName("maximumAuthenticationTimeoutInSeconds")]
    public int? MaximumAuthenticationTimeoutInSeconds { get; set; }

    [JsonPropertyName("maximumEAPOLStartMessages")]
    public int? MaximumEAPOLStartMessages { get; set; }

    [JsonPropertyName("maximumNumberOfPairwiseMasterKeysInCache")]
    public int? MaximumNumberOfPairwiseMasterKeysInCache { get; set; }

    [JsonPropertyName("maximumPairwiseMasterKeyCacheTimeInMinutes")]
    public int? MaximumPairwiseMasterKeyCacheTimeInMinutes { get; set; }

    [JsonPropertyName("maximumPreAuthenticationAttempts")]
    public int? MaximumPreAuthenticationAttempts { get; set; }

    [JsonPropertyName("meteredConnectionLimit")]
    public WindowsWifiEnterpriseEAPConfigurationMeteredConnectionLimitConstant? MeteredConnectionLimit { get; set; }

    [JsonPropertyName("networkName")]
    public string? NetworkName { get; set; }

    [JsonPropertyName("networkSingleSignOn")]
    public WindowsWifiEnterpriseEAPConfigurationNetworkSingleSignOnConstant? NetworkSingleSignOn { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("outerIdentityPrivacyTemporaryValue")]
    public string? OuterIdentityPrivacyTemporaryValue { get; set; }

    [JsonPropertyName("performServerValidation")]
    public bool? PerformServerValidation { get; set; }

    [JsonPropertyName("preSharedKey")]
    public string? PreSharedKey { get; set; }

    [JsonPropertyName("promptForAdditionalAuthenticationCredentials")]
    public bool? PromptForAdditionalAuthenticationCredentials { get; set; }

    [JsonPropertyName("proxyAutomaticConfigurationUrl")]
    public string? ProxyAutomaticConfigurationUrl { get; set; }

    [JsonPropertyName("proxyManualAddress")]
    public string? ProxyManualAddress { get; set; }

    [JsonPropertyName("proxyManualPort")]
    public int? ProxyManualPort { get; set; }

    [JsonPropertyName("proxySetting")]
    public WindowsWifiEnterpriseEAPConfigurationProxySettingConstant? ProxySetting { get; set; }

    [JsonPropertyName("requireCryptographicBinding")]
    public bool? RequireCryptographicBinding { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("rootCertificateForClientValidation")]
    public Windows81TrustedRootCertificateModel? RootCertificateForClientValidation { get; set; }

    [JsonPropertyName("rootCertificatesForServerValidation")]
    public List<Windows81TrustedRootCertificateModel>? RootCertificatesForServerValidation { get; set; }

    [JsonPropertyName("ssid")]
    public string? Ssid { get; set; }

    [JsonPropertyName("supportsScopeTags")]
    public bool? SupportsScopeTags { get; set; }

    [JsonPropertyName("trustedServerCertificateNames")]
    public List<string>? TrustedServerCertificateNames { get; set; }

    [JsonPropertyName("userBasedVirtualLan")]
    public bool? UserBasedVirtualLan { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("wifiSecurityType")]
    public WindowsWifiEnterpriseEAPConfigurationWifiSecurityTypeConstant? WifiSecurityType { get; set; }
}
