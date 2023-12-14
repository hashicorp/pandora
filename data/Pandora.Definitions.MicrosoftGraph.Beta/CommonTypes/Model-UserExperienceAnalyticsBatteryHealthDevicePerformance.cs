// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserExperienceAnalyticsBatteryHealthDevicePerformanceModel
{
    [JsonPropertyName("batteryAgeInDays")]
    public int? BatteryAgeInDays { get; set; }

    [JsonPropertyName("deviceBatteriesDetails")]
    public List<UserExperienceAnalyticsDeviceBatteryDetailModel>? DeviceBatteriesDetails { get; set; }

    [JsonPropertyName("deviceBatteryCount")]
    public int? DeviceBatteryCount { get; set; }

    [JsonPropertyName("deviceBatteryHealthScore")]
    public int? DeviceBatteryHealthScore { get; set; }

    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("estimatedRuntimeInMinutes")]
    public int? EstimatedRuntimeInMinutes { get; set; }

    [JsonPropertyName("fullBatteryDrainCount")]
    public int? FullBatteryDrainCount { get; set; }

    [JsonPropertyName("healthStatus")]
    public UserExperienceAnalyticsBatteryHealthDevicePerformanceHealthStatusConstant? HealthStatus { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonPropertyName("maxCapacityPercentage")]
    public int? MaxCapacityPercentage { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
