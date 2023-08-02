// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AndroidCompliancePolicyModel
{
    [JsonPropertyName("assignments")]
    public List<DeviceCompliancePolicyAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceSettingStateSummaries")]
    public List<SettingStateDeviceSummaryModel>? DeviceSettingStateSummaries { get; set; }

    [JsonPropertyName("deviceStatusOverview")]
    public DeviceComplianceDeviceOverviewModel? DeviceStatusOverview { get; set; }

    [JsonPropertyName("deviceStatuses")]
    public List<DeviceComplianceDeviceStatusModel>? DeviceStatuses { get; set; }

    [JsonPropertyName("deviceThreatProtectionEnabled")]
    public bool? DeviceThreatProtectionEnabled { get; set; }

    [JsonPropertyName("deviceThreatProtectionRequiredSecurityLevel")]
    public DeviceThreatProtectionLevelConstant? DeviceThreatProtectionRequiredSecurityLevel { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("minAndroidSecurityPatchLevel")]
    public string? MinAndroidSecurityPatchLevel { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("osMaximumVersion")]
    public string? OsMaximumVersion { get; set; }

    [JsonPropertyName("osMinimumVersion")]
    public string? OsMinimumVersion { get; set; }

    [JsonPropertyName("passwordExpirationDays")]
    public int? PasswordExpirationDays { get; set; }

    [JsonPropertyName("passwordMinimumLength")]
    public int? PasswordMinimumLength { get; set; }

    [JsonPropertyName("passwordMinutesOfInactivityBeforeLock")]
    public int? PasswordMinutesOfInactivityBeforeLock { get; set; }

    [JsonPropertyName("passwordPreviousPasswordBlockCount")]
    public int? PasswordPreviousPasswordBlockCount { get; set; }

    [JsonPropertyName("passwordRequired")]
    public bool? PasswordRequired { get; set; }

    [JsonPropertyName("passwordRequiredType")]
    public AndroidRequiredPasswordTypeConstant? PasswordRequiredType { get; set; }

    [JsonPropertyName("scheduledActionsForRule")]
    public List<DeviceComplianceScheduledActionForRuleModel>? ScheduledActionsForRule { get; set; }

    [JsonPropertyName("securityBlockJailbrokenDevices")]
    public bool? SecurityBlockJailbrokenDevices { get; set; }

    [JsonPropertyName("securityDisableUsbDebugging")]
    public bool? SecurityDisableUsbDebugging { get; set; }

    [JsonPropertyName("securityPreventInstallAppsFromUnknownSources")]
    public bool? SecurityPreventInstallAppsFromUnknownSources { get; set; }

    [JsonPropertyName("securityRequireCompanyPortalAppIntegrity")]
    public bool? SecurityRequireCompanyPortalAppIntegrity { get; set; }

    [JsonPropertyName("securityRequireGooglePlayServices")]
    public bool? SecurityRequireGooglePlayServices { get; set; }

    [JsonPropertyName("securityRequireSafetyNetAttestationBasicIntegrity")]
    public bool? SecurityRequireSafetyNetAttestationBasicIntegrity { get; set; }

    [JsonPropertyName("securityRequireSafetyNetAttestationCertifiedDevice")]
    public bool? SecurityRequireSafetyNetAttestationCertifiedDevice { get; set; }

    [JsonPropertyName("securityRequireUpToDateSecurityProviders")]
    public bool? SecurityRequireUpToDateSecurityProviders { get; set; }

    [JsonPropertyName("securityRequireVerifyApps")]
    public bool? SecurityRequireVerifyApps { get; set; }

    [JsonPropertyName("storageRequireEncryption")]
    public bool? StorageRequireEncryption { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceComplianceUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceComplianceUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
