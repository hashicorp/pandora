// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedTenantsAppPerformanceModel
{
    [JsonPropertyName("appFriendlyName")]
    public string? AppFriendlyName { get; set; }

    [JsonPropertyName("appName")]
    public string? AppName { get; set; }

    [JsonPropertyName("appPublisher")]
    public string? AppPublisher { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastUpdatedDateTime")]
    public DateTime? LastUpdatedDateTime { get; set; }

    [JsonPropertyName("meanTimeToFailureInMinutes")]
    public int? MeanTimeToFailureInMinutes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("tenantDisplayName")]
    public string? TenantDisplayName { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("totalActiveDeviceCount")]
    public int? TotalActiveDeviceCount { get; set; }

    [JsonPropertyName("totalAppCrashCount")]
    public int? TotalAppCrashCount { get; set; }

    [JsonPropertyName("totalAppFreezeCount")]
    public int? TotalAppFreezeCount { get; set; }
}
