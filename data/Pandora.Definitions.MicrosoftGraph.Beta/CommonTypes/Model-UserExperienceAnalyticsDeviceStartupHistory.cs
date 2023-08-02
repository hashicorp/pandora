// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserExperienceAnalyticsDeviceStartupHistoryModel
{
    [JsonPropertyName("coreBootTimeInMs")]
    public int? CoreBootTimeInMs { get; set; }

    [JsonPropertyName("coreLoginTimeInMs")]
    public int? CoreLoginTimeInMs { get; set; }

    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("featureUpdateBootTimeInMs")]
    public int? FeatureUpdateBootTimeInMs { get; set; }

    [JsonPropertyName("groupPolicyBootTimeInMs")]
    public int? GroupPolicyBootTimeInMs { get; set; }

    [JsonPropertyName("groupPolicyLoginTimeInMs")]
    public int? GroupPolicyLoginTimeInMs { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isFeatureUpdate")]
    public bool? IsFeatureUpdate { get; set; }

    [JsonPropertyName("isFirstLogin")]
    public bool? IsFirstLogin { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operatingSystemVersion")]
    public string? OperatingSystemVersion { get; set; }

    [JsonPropertyName("responsiveDesktopTimeInMs")]
    public int? ResponsiveDesktopTimeInMs { get; set; }

    [JsonPropertyName("restartCategory")]
    public UserExperienceAnalyticsOperatingSystemRestartCategoryConstant? RestartCategory { get; set; }

    [JsonPropertyName("restartFaultBucket")]
    public string? RestartFaultBucket { get; set; }

    [JsonPropertyName("restartStopCode")]
    public string? RestartStopCode { get; set; }

    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("totalBootTimeInMs")]
    public int? TotalBootTimeInMs { get; set; }

    [JsonPropertyName("totalLoginTimeInMs")]
    public int? TotalLoginTimeInMs { get; set; }
}
