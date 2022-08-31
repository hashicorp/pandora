using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2021_09_03_preview.ScalingPlan;


internal class ScalingScheduleModel
{
    [JsonPropertyName("daysOfWeek")]
    public List<DaysOfWeekConstant>? DaysOfWeek { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("offPeakLoadBalancingAlgorithm")]
    public SessionHostLoadBalancingAlgorithmConstant? OffPeakLoadBalancingAlgorithm { get; set; }

    [JsonPropertyName("offPeakStartTime")]
    public TimeModel? OffPeakStartTime { get; set; }

    [JsonPropertyName("peakLoadBalancingAlgorithm")]
    public SessionHostLoadBalancingAlgorithmConstant? PeakLoadBalancingAlgorithm { get; set; }

    [JsonPropertyName("peakStartTime")]
    public TimeModel? PeakStartTime { get; set; }

    [JsonPropertyName("rampDownCapacityThresholdPct")]
    public int? RampDownCapacityThresholdPct { get; set; }

    [JsonPropertyName("rampDownForceLogoffUsers")]
    public bool? RampDownForceLogoffUsers { get; set; }

    [JsonPropertyName("rampDownLoadBalancingAlgorithm")]
    public SessionHostLoadBalancingAlgorithmConstant? RampDownLoadBalancingAlgorithm { get; set; }

    [JsonPropertyName("rampDownMinimumHostsPct")]
    public int? RampDownMinimumHostsPct { get; set; }

    [JsonPropertyName("rampDownNotificationMessage")]
    public string? RampDownNotificationMessage { get; set; }

    [JsonPropertyName("rampDownStartTime")]
    public TimeModel? RampDownStartTime { get; set; }

    [JsonPropertyName("rampDownStopHostsWhen")]
    public StopHostsWhenConstant? RampDownStopHostsWhen { get; set; }

    [JsonPropertyName("rampDownWaitTimeMinutes")]
    public int? RampDownWaitTimeMinutes { get; set; }

    [JsonPropertyName("rampUpCapacityThresholdPct")]
    public int? RampUpCapacityThresholdPct { get; set; }

    [JsonPropertyName("rampUpLoadBalancingAlgorithm")]
    public SessionHostLoadBalancingAlgorithmConstant? RampUpLoadBalancingAlgorithm { get; set; }

    [JsonPropertyName("rampUpMinimumHostsPct")]
    public int? RampUpMinimumHostsPct { get; set; }

    [JsonPropertyName("rampUpStartTime")]
    public TimeModel? RampUpStartTime { get; set; }
}
