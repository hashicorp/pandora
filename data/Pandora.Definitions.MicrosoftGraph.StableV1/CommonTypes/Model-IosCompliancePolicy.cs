// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class IosCompliancePolicyModel
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
    public IosCompliancePolicyDeviceThreatProtectionRequiredSecurityLevelConstant? DeviceThreatProtectionRequiredSecurityLevel { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("managedEmailProfileRequired")]
    public bool? ManagedEmailProfileRequired { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("osMaximumVersion")]
    public string? OsMaximumVersion { get; set; }

    [JsonPropertyName("osMinimumVersion")]
    public string? OsMinimumVersion { get; set; }

    [JsonPropertyName("passcodeBlockSimple")]
    public bool? PasscodeBlockSimple { get; set; }

    [JsonPropertyName("passcodeExpirationDays")]
    public int? PasscodeExpirationDays { get; set; }

    [JsonPropertyName("passcodeMinimumCharacterSetCount")]
    public int? PasscodeMinimumCharacterSetCount { get; set; }

    [JsonPropertyName("passcodeMinimumLength")]
    public int? PasscodeMinimumLength { get; set; }

    [JsonPropertyName("passcodeMinutesOfInactivityBeforeLock")]
    public int? PasscodeMinutesOfInactivityBeforeLock { get; set; }

    [JsonPropertyName("passcodePreviousPasscodeBlockCount")]
    public int? PasscodePreviousPasscodeBlockCount { get; set; }

    [JsonPropertyName("passcodeRequired")]
    public bool? PasscodeRequired { get; set; }

    [JsonPropertyName("passcodeRequiredType")]
    public IosCompliancePolicyPasscodeRequiredTypeConstant? PasscodeRequiredType { get; set; }

    [JsonPropertyName("scheduledActionsForRule")]
    public List<DeviceComplianceScheduledActionForRuleModel>? ScheduledActionsForRule { get; set; }

    [JsonPropertyName("securityBlockJailbrokenDevices")]
    public bool? SecurityBlockJailbrokenDevices { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceComplianceUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceComplianceUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
