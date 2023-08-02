// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SharedPCConfigurationModel
{
    [JsonPropertyName("accountManagerPolicy")]
    public SharedPCAccountManagerPolicyModel? AccountManagerPolicy { get; set; }

    [JsonPropertyName("allowLocalStorage")]
    public bool? AllowLocalStorage { get; set; }

    [JsonPropertyName("allowedAccounts")]
    public SharedPCAllowedAccountTypeConstant? AllowedAccounts { get; set; }

    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceSettingStateSummaries")]
    public List<SettingStateDeviceSummaryModel>? DeviceSettingStateSummaries { get; set; }

    [JsonPropertyName("deviceStatusOverview")]
    public DeviceConfigurationDeviceOverviewModel? DeviceStatusOverview { get; set; }

    [JsonPropertyName("deviceStatuses")]
    public List<DeviceConfigurationDeviceStatusModel>? DeviceStatuses { get; set; }

    [JsonPropertyName("disableAccountManager")]
    public bool? DisableAccountManager { get; set; }

    [JsonPropertyName("disableEduPolicies")]
    public bool? DisableEduPolicies { get; set; }

    [JsonPropertyName("disablePowerPolicies")]
    public bool? DisablePowerPolicies { get; set; }

    [JsonPropertyName("disableSignInOnResume")]
    public bool? DisableSignInOnResume { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("idleTimeBeforeSleepInSeconds")]
    public int? IdleTimeBeforeSleepInSeconds { get; set; }

    [JsonPropertyName("kioskAppDisplayName")]
    public string? KioskAppDisplayName { get; set; }

    [JsonPropertyName("kioskAppUserModelId")]
    public string? KioskAppUserModelId { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("maintenanceStartTime")]
    public DateTime? MaintenanceStartTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
