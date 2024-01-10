// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserExperienceAnalyticsResourcePerformanceModel
{
    [JsonPropertyName("averageSpikeTimeScore")]
    public int? AverageSpikeTimeScore { get; set; }

    [JsonPropertyName("cpuSpikeTimeScore")]
    public int? CpuSpikeTimeScore { get; set; }

    [JsonPropertyName("deviceCount")]
    public int? DeviceCount { get; set; }

    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("deviceResourcePerformanceScore")]
    public int? DeviceResourcePerformanceScore { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("ramSpikeTimeScore")]
    public int? RamSpikeTimeScore { get; set; }
}
