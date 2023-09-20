// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserExperienceAnalyticsAppHealthAppPerformanceByAppVersionDetailsModel
{
    [JsonPropertyName("appCrashCount")]
    public int? AppCrashCount { get; set; }

    [JsonPropertyName("appDisplayName")]
    public string? AppDisplayName { get; set; }

    [JsonPropertyName("appName")]
    public string? AppName { get; set; }

    [JsonPropertyName("appPublisher")]
    public string? AppPublisher { get; set; }

    [JsonPropertyName("appVersion")]
    public string? AppVersion { get; set; }

    [JsonPropertyName("deviceCountWithCrashes")]
    public int? DeviceCountWithCrashes { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isLatestUsedVersion")]
    public bool? IsLatestUsedVersion { get; set; }

    [JsonPropertyName("isMostUsedVersion")]
    public bool? IsMostUsedVersion { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
