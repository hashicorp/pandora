// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserExperienceAnalyticsBatteryHealthModelPerformanceModel
{
    [JsonPropertyName("activeDevices")]
    public int? ActiveDevices { get; set; }

    [JsonPropertyName("averageBatteryAgeInDays")]
    public int? AverageBatteryAgeInDays { get; set; }

    [JsonPropertyName("averageEstimatedRuntimeInMinutes")]
    public int? AverageEstimatedRuntimeInMinutes { get; set; }

    [JsonPropertyName("averageMaxCapacityPercentage")]
    public int? AverageMaxCapacityPercentage { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonPropertyName("meanFullBatteryDrainCount")]
    public int? MeanFullBatteryDrainCount { get; set; }

    [JsonPropertyName("medianEstimatedRuntimeInMinutes")]
    public int? MedianEstimatedRuntimeInMinutes { get; set; }

    [JsonPropertyName("medianFullBatteryDrainCount")]
    public int? MedianFullBatteryDrainCount { get; set; }

    [JsonPropertyName("medianMaxCapacityPercentage")]
    public int? MedianMaxCapacityPercentage { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("modelBatteryHealthScore")]
    public int? ModelBatteryHealthScore { get; set; }

    [JsonPropertyName("modelHealthStatus")]
    public UserExperienceAnalyticsBatteryHealthModelPerformanceModelHealthStatusConstant? ModelHealthStatus { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
