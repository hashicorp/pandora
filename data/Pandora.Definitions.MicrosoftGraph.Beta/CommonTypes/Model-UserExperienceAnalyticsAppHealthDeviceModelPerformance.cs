// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserExperienceAnalyticsAppHealthDeviceModelPerformanceModel
{
    [JsonPropertyName("activeDeviceCount")]
    public int? ActiveDeviceCount { get; set; }

    [JsonPropertyName("deviceManufacturer")]
    public string? DeviceManufacturer { get; set; }

    [JsonPropertyName("deviceModel")]
    public string? DeviceModel { get; set; }

    [JsonPropertyName("healthStatus")]
    public UserExperienceAnalyticsHealthStateConstant? HealthStatus { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("meanTimeToFailureInMinutes")]
    public int? MeanTimeToFailureInMinutes { get; set; }

    [JsonPropertyName("modelAppHealthStatus")]
    public string? ModelAppHealthStatus { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
