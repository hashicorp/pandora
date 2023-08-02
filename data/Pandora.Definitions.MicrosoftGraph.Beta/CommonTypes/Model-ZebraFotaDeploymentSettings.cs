// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ZebraFotaDeploymentSettingsModel
{
    [JsonPropertyName("batteryRuleMinimumBatteryLevelPercentage")]
    public int? BatteryRuleMinimumBatteryLevelPercentage { get; set; }

    [JsonPropertyName("batteryRuleRequireCharger")]
    public bool? BatteryRuleRequireCharger { get; set; }

    [JsonPropertyName("deviceModel")]
    public string? DeviceModel { get; set; }

    [JsonPropertyName("downloadRuleNetworkType")]
    public ZebraFotaNetworkTypeConstant? DownloadRuleNetworkType { get; set; }

    [JsonPropertyName("downloadRuleStartDateTime")]
    public DateTime? DownloadRuleStartDateTime { get; set; }

    [JsonPropertyName("firmwareTargetArtifactDescription")]
    public string? FirmwareTargetArtifactDescription { get; set; }

    [JsonPropertyName("firmwareTargetBoardSupportPackageVersion")]
    public string? FirmwareTargetBoardSupportPackageVersion { get; set; }

    [JsonPropertyName("firmwareTargetOsVersion")]
    public string? FirmwareTargetOsVersion { get; set; }

    [JsonPropertyName("firmwareTargetPatch")]
    public string? FirmwareTargetPatch { get; set; }

    [JsonPropertyName("installRuleStartDateTime")]
    public DateTime? InstallRuleStartDateTime { get; set; }

    [JsonPropertyName("installRuleWindowEndTime")]
    public DateTime? InstallRuleWindowEndTime { get; set; }

    [JsonPropertyName("installRuleWindowStartTime")]
    public DateTime? InstallRuleWindowStartTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("scheduleDurationInDays")]
    public int? ScheduleDurationInDays { get; set; }

    [JsonPropertyName("scheduleMode")]
    public ZebraFotaScheduleModeConstant? ScheduleMode { get; set; }

    [JsonPropertyName("timeZoneOffsetInMinutes")]
    public int? TimeZoneOffsetInMinutes { get; set; }

    [JsonPropertyName("updateType")]
    public ZebraFotaUpdateTypeConstant? UpdateType { get; set; }
}
