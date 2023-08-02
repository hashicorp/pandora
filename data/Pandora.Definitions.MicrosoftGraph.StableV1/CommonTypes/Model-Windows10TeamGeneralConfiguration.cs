// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class Windows10TeamGeneralConfigurationModel
{
    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("azureOperationalInsightsBlockTelemetry")]
    public bool? AzureOperationalInsightsBlockTelemetry { get; set; }

    [JsonPropertyName("azureOperationalInsightsWorkspaceId")]
    public string? AzureOperationalInsightsWorkspaceId { get; set; }

    [JsonPropertyName("azureOperationalInsightsWorkspaceKey")]
    public string? AzureOperationalInsightsWorkspaceKey { get; set; }

    [JsonPropertyName("connectAppBlockAutoLaunch")]
    public bool? ConnectAppBlockAutoLaunch { get; set; }

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

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("maintenanceWindowBlocked")]
    public bool? MaintenanceWindowBlocked { get; set; }

    [JsonPropertyName("maintenanceWindowDurationInHours")]
    public int? MaintenanceWindowDurationInHours { get; set; }

    [JsonPropertyName("maintenanceWindowStartTime")]
    public DateTime? MaintenanceWindowStartTime { get; set; }

    [JsonPropertyName("miracastBlocked")]
    public bool? MiracastBlocked { get; set; }

    [JsonPropertyName("miracastChannel")]
    public MiracastChannelConstant? MiracastChannel { get; set; }

    [JsonPropertyName("miracastRequirePin")]
    public bool? MiracastRequirePin { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("settingsBlockMyMeetingsAndFiles")]
    public bool? SettingsBlockMyMeetingsAndFiles { get; set; }

    [JsonPropertyName("settingsBlockSessionResume")]
    public bool? SettingsBlockSessionResume { get; set; }

    [JsonPropertyName("settingsBlockSigninSuggestions")]
    public bool? SettingsBlockSigninSuggestions { get; set; }

    [JsonPropertyName("settingsDefaultVolume")]
    public int? SettingsDefaultVolume { get; set; }

    [JsonPropertyName("settingsScreenTimeoutInMinutes")]
    public int? SettingsScreenTimeoutInMinutes { get; set; }

    [JsonPropertyName("settingsSessionTimeoutInMinutes")]
    public int? SettingsSessionTimeoutInMinutes { get; set; }

    [JsonPropertyName("settingsSleepTimeoutInMinutes")]
    public int? SettingsSleepTimeoutInMinutes { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("welcomeScreenBackgroundImageUrl")]
    public string? WelcomeScreenBackgroundImageUrl { get; set; }

    [JsonPropertyName("welcomeScreenBlockAutomaticWakeUp")]
    public bool? WelcomeScreenBlockAutomaticWakeUp { get; set; }

    [JsonPropertyName("welcomeScreenMeetingInformation")]
    public WelcomeScreenMeetingInformationConstant? WelcomeScreenMeetingInformation { get; set; }
}
