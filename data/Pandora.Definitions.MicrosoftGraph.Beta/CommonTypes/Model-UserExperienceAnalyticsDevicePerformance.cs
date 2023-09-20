// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserExperienceAnalyticsDevicePerformanceModel
{
    [JsonPropertyName("blueScreenCount")]
    public int? BlueScreenCount { get; set; }

    [JsonPropertyName("bootScore")]
    public int? BootScore { get; set; }

    [JsonPropertyName("coreBootTimeInMs")]
    public int? CoreBootTimeInMs { get; set; }

    [JsonPropertyName("coreLoginTimeInMs")]
    public int? CoreLoginTimeInMs { get; set; }

    [JsonPropertyName("deviceCount")]
    public int? DeviceCount { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("diskType")]
    public UserExperienceAnalyticsDevicePerformanceDiskTypeConstant? DiskType { get; set; }

    [JsonPropertyName("groupPolicyBootTimeInMs")]
    public int? GroupPolicyBootTimeInMs { get; set; }

    [JsonPropertyName("groupPolicyLoginTimeInMs")]
    public int? GroupPolicyLoginTimeInMs { get; set; }

    [JsonPropertyName("healthStatus")]
    public UserExperienceAnalyticsDevicePerformanceHealthStatusConstant? HealthStatus { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("loginScore")]
    public int? LoginScore { get; set; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operatingSystemVersion")]
    public string? OperatingSystemVersion { get; set; }

    [JsonPropertyName("responsiveDesktopTimeInMs")]
    public int? ResponsiveDesktopTimeInMs { get; set; }

    [JsonPropertyName("restartCount")]
    public int? RestartCount { get; set; }
}
