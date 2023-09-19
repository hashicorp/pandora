// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Windows10CompliancePolicyModel
{
    [JsonPropertyName("activeFirewallRequired")]
    public bool? ActiveFirewallRequired { get; set; }

    [JsonPropertyName("antiSpywareRequired")]
    public bool? AntiSpywareRequired { get; set; }

    [JsonPropertyName("antivirusRequired")]
    public bool? AntivirusRequired { get; set; }

    [JsonPropertyName("assignments")]
    public List<DeviceCompliancePolicyAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("bitLockerEnabled")]
    public bool? BitLockerEnabled { get; set; }

    [JsonPropertyName("codeIntegrityEnabled")]
    public bool? CodeIntegrityEnabled { get; set; }

    [JsonPropertyName("configurationManagerComplianceRequired")]
    public bool? ConfigurationManagerComplianceRequired { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("defenderEnabled")]
    public bool? DefenderEnabled { get; set; }

    [JsonPropertyName("defenderVersion")]
    public string? DefenderVersion { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceCompliancePolicyScript")]
    public DeviceCompliancePolicyScriptModel? DeviceCompliancePolicyScript { get; set; }

    [JsonPropertyName("deviceSettingStateSummaries")]
    public List<SettingStateDeviceSummaryModel>? DeviceSettingStateSummaries { get; set; }

    [JsonPropertyName("deviceStatusOverview")]
    public DeviceComplianceDeviceOverviewModel? DeviceStatusOverview { get; set; }

    [JsonPropertyName("deviceStatuses")]
    public List<DeviceComplianceDeviceStatusModel>? DeviceStatuses { get; set; }

    [JsonPropertyName("deviceThreatProtectionEnabled")]
    public bool? DeviceThreatProtectionEnabled { get; set; }

    [JsonPropertyName("deviceThreatProtectionRequiredSecurityLevel")]
    public Windows10CompliancePolicyDeviceThreatProtectionRequiredSecurityLevelConstant? DeviceThreatProtectionRequiredSecurityLevel { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("earlyLaunchAntiMalwareDriverEnabled")]
    public bool? EarlyLaunchAntiMalwareDriverEnabled { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("mobileOsMaximumVersion")]
    public string? MobileOsMaximumVersion { get; set; }

    [JsonPropertyName("mobileOsMinimumVersion")]
    public string? MobileOsMinimumVersion { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("osMaximumVersion")]
    public string? OsMaximumVersion { get; set; }

    [JsonPropertyName("osMinimumVersion")]
    public string? OsMinimumVersion { get; set; }

    [JsonPropertyName("passwordBlockSimple")]
    public bool? PasswordBlockSimple { get; set; }

    [JsonPropertyName("passwordExpirationDays")]
    public int? PasswordExpirationDays { get; set; }

    [JsonPropertyName("passwordMinimumCharacterSetCount")]
    public int? PasswordMinimumCharacterSetCount { get; set; }

    [JsonPropertyName("passwordMinimumLength")]
    public int? PasswordMinimumLength { get; set; }

    [JsonPropertyName("passwordMinutesOfInactivityBeforeLock")]
    public int? PasswordMinutesOfInactivityBeforeLock { get; set; }

    [JsonPropertyName("passwordPreviousPasswordBlockCount")]
    public int? PasswordPreviousPasswordBlockCount { get; set; }

    [JsonPropertyName("passwordRequired")]
    public bool? PasswordRequired { get; set; }

    [JsonPropertyName("passwordRequiredToUnlockFromIdle")]
    public bool? PasswordRequiredToUnlockFromIdle { get; set; }

    [JsonPropertyName("passwordRequiredType")]
    public Windows10CompliancePolicyPasswordRequiredTypeConstant? PasswordRequiredType { get; set; }

    [JsonPropertyName("requireHealthyDeviceReport")]
    public bool? RequireHealthyDeviceReport { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("rtpEnabled")]
    public bool? RtpEnabled { get; set; }

    [JsonPropertyName("scheduledActionsForRule")]
    public List<DeviceComplianceScheduledActionForRuleModel>? ScheduledActionsForRule { get; set; }

    [JsonPropertyName("secureBootEnabled")]
    public bool? SecureBootEnabled { get; set; }

    [JsonPropertyName("signatureOutOfDate")]
    public bool? SignatureOutOfDate { get; set; }

    [JsonPropertyName("storageRequireEncryption")]
    public bool? StorageRequireEncryption { get; set; }

    [JsonPropertyName("tpmRequired")]
    public bool? TpmRequired { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceComplianceUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceComplianceUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("validOperatingSystemBuildRanges")]
    public List<OperatingSystemVersionRangeModel>? ValidOperatingSystemBuildRanges { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
