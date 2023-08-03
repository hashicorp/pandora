// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceAppPerformanceModel
{
    [JsonPropertyName("appFriendlyName")]
    public string? AppFriendlyName { get; set; }

    [JsonPropertyName("appName")]
    public string? AppName { get; set; }

    [JsonPropertyName("appPublisher")]
    public string? AppPublisher { get; set; }

    [JsonPropertyName("appVersion")]
    public string? AppVersion { get; set; }

    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("deviceManufacturer")]
    public string? DeviceManufacturer { get; set; }

    [JsonPropertyName("deviceModel")]
    public string? DeviceModel { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("healthStatus")]
    public string? HealthStatus { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isLatestUsedVersion")]
    public int? IsLatestUsedVersion { get; set; }

    [JsonPropertyName("isMostUsedVersion")]
    public int? IsMostUsedVersion { get; set; }

    [JsonPropertyName("lastUpdatedDateTime")]
    public DateTime? LastUpdatedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("tenantDisplayName")]
    public string? TenantDisplayName { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("totalAppCrashCount")]
    public int? TotalAppCrashCount { get; set; }

    [JsonPropertyName("totalAppFreezeCount")]
    public int? TotalAppFreezeCount { get; set; }
}
