using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.TargetComputeSizes;


internal class TargetComputeSizePropertiesModel
{
    [JsonPropertyName("cpuCoresCount")]
    public int? CpuCoresCount { get; set; }

    [JsonPropertyName("errors")]
    public List<ComputeSizeErrorDetailsModel>? Errors { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("highIopsSupported")]
    public string? HighIopsSupported { get; set; }

    [JsonPropertyName("hyperVGenerations")]
    public List<string>? HyperVGenerations { get; set; }

    [JsonPropertyName("maxDataDiskCount")]
    public int? MaxDataDiskCount { get; set; }

    [JsonPropertyName("maxNicsCount")]
    public int? MaxNicsCount { get; set; }

    [JsonPropertyName("memoryInGB")]
    public float? MemoryInGB { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("vCPUsAvailable")]
    public int? VCPUsAvailable { get; set; }
}
