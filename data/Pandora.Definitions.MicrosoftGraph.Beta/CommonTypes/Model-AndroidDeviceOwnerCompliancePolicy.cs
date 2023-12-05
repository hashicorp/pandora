// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AndroidDeviceOwnerCompliancePolicyModel
{
    [JsonPropertyName("advancedThreatProtectionRequiredSecurityLevel")]
    public AndroidDeviceOwnerCompliancePolicyAdvancedThreatProtectionRequiredSecurityLevelConstant? AdvancedThreatProtectionRequiredSecurityLevel { get; set; }

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
    public AndroidDeviceOwnerCompliancePolicyDeviceThreatProtectionRequiredSecurityLevelConstant? DeviceThreatProtectionRequiredSecurityLevel { get; set; }

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

    [JsonPropertyName("passwordMinimumLetterCharacters")]
    public int? PasswordMinimumLetterCharacters { get; set; }

    [JsonPropertyName("passwordMinimumLowerCaseCharacters")]
    public int? PasswordMinimumLowerCaseCharacters { get; set; }

    [JsonPropertyName("passwordMinimumNonLetterCharacters")]
    public int? PasswordMinimumNonLetterCharacters { get; set; }

    [JsonPropertyName("passwordMinimumNumericCharacters")]
    public int? PasswordMinimumNumericCharacters { get; set; }

    [JsonPropertyName("passwordMinimumSymbolCharacters")]
    public int? PasswordMinimumSymbolCharacters { get; set; }

    [JsonPropertyName("passwordMinimumUpperCaseCharacters")]
    public int? PasswordMinimumUpperCaseCharacters { get; set; }

    [JsonPropertyName("passwordMinutesOfInactivityBeforeLock")]
    public int? PasswordMinutesOfInactivityBeforeLock { get; set; }

    [JsonPropertyName("passwordPreviousPasswordCountToBlock")]
    public int? PasswordPreviousPasswordCountToBlock { get; set; }

    [JsonPropertyName("passwordRequired")]
    public bool? PasswordRequired { get; set; }

    [JsonPropertyName("passwordRequiredType")]
    public AndroidDeviceOwnerCompliancePolicyPasswordRequiredTypeConstant? PasswordRequiredType { get; set; }

    [JsonPropertyName("requireNoPendingSystemUpdates")]
    public bool? RequireNoPendingSystemUpdates { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("scheduledActionsForRule")]
    public List<DeviceComplianceScheduledActionForRuleModel>? ScheduledActionsForRule { get; set; }

    [JsonPropertyName("securityRequireIntuneAppIntegrity")]
    public bool? SecurityRequireIntuneAppIntegrity { get; set; }

    [JsonPropertyName("securityRequireSafetyNetAttestationBasicIntegrity")]
    public bool? SecurityRequireSafetyNetAttestationBasicIntegrity { get; set; }

    [JsonPropertyName("securityRequireSafetyNetAttestationCertifiedDevice")]
    public bool? SecurityRequireSafetyNetAttestationCertifiedDevice { get; set; }

    [JsonPropertyName("storageRequireEncryption")]
    public bool? StorageRequireEncryption { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceComplianceUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceComplianceUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
