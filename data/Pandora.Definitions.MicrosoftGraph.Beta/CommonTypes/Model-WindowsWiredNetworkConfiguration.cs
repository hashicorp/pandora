// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsWiredNetworkConfigurationModel
{
    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("authenticationBlockPeriodInMinutes")]
    public int? AuthenticationBlockPeriodInMinutes { get; set; }

    [JsonPropertyName("authenticationMethod")]
    public WiredNetworkAuthenticationMethodConstant? AuthenticationMethod { get; set; }

    [JsonPropertyName("authenticationPeriodInSeconds")]
    public int? AuthenticationPeriodInSeconds { get; set; }

    [JsonPropertyName("authenticationRetryDelayPeriodInSeconds")]
    public int? AuthenticationRetryDelayPeriodInSeconds { get; set; }

    [JsonPropertyName("authenticationType")]
    public WiredNetworkAuthenticationTypeConstant? AuthenticationType { get; set; }

    [JsonPropertyName("cacheCredentials")]
    public bool? CacheCredentials { get; set; }

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
    public EapTypeConstant? EapType { get; set; }

    [JsonPropertyName("eapolStartPeriodInSeconds")]
    public int? EapolStartPeriodInSeconds { get; set; }

    [JsonPropertyName("enforce8021X")]
    public bool? Enforce8021X { get; set; }

    [JsonPropertyName("forceFIPSCompliance")]
    public bool? ForceFIPSCompliance { get; set; }

    [JsonPropertyName("groupAssignments")]
    public List<DeviceConfigurationGroupAssignmentModel>? GroupAssignments { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("identityCertificateForClientAuthentication")]
    public WindowsCertificateProfileBaseModel? IdentityCertificateForClientAuthentication { get; set; }

    [JsonPropertyName("innerAuthenticationProtocolForEAPTTLS")]
    public NonEapAuthenticationMethodForEapTtlsTypeConstant? InnerAuthenticationProtocolForEAPTTLS { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("maximumAuthenticationFailures")]
    public int? MaximumAuthenticationFailures { get; set; }

    [JsonPropertyName("maximumEAPOLStartMessages")]
    public int? MaximumEAPOLStartMessages { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("outerIdentityPrivacyTemporaryValue")]
    public string? OuterIdentityPrivacyTemporaryValue { get; set; }

    [JsonPropertyName("performServerValidation")]
    public bool? PerformServerValidation { get; set; }

    [JsonPropertyName("requireCryptographicBinding")]
    public bool? RequireCryptographicBinding { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("rootCertificateForClientValidation")]
    public Windows81TrustedRootCertificateModel? RootCertificateForClientValidation { get; set; }

    [JsonPropertyName("rootCertificatesForServerValidation")]
    public List<Windows81TrustedRootCertificateModel>? RootCertificatesForServerValidation { get; set; }

    [JsonPropertyName("secondaryAuthenticationMethod")]
    public WiredNetworkAuthenticationMethodConstant? SecondaryAuthenticationMethod { get; set; }

    [JsonPropertyName("secondaryIdentityCertificateForClientAuthentication")]
    public WindowsCertificateProfileBaseModel? SecondaryIdentityCertificateForClientAuthentication { get; set; }

    [JsonPropertyName("secondaryRootCertificateForClientValidation")]
    public Windows81TrustedRootCertificateModel? SecondaryRootCertificateForClientValidation { get; set; }

    [JsonPropertyName("supportsScopeTags")]
    public bool? SupportsScopeTags { get; set; }

    [JsonPropertyName("trustedServerCertificateNames")]
    public List<string>? TrustedServerCertificateNames { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
