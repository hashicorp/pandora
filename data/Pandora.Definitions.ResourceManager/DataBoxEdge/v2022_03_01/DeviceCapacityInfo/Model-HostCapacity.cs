using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.DeviceCapacityInfo;


internal class HostCapacityModel
{
    [JsonPropertyName("availableGpuCount")]
    public int? AvailableGpuCount { get; set; }

    [JsonPropertyName("effectiveAvailableMemoryMbOnHost")]
    public int? EffectiveAvailableMemoryMbOnHost { get; set; }

    [JsonPropertyName("gpuType")]
    public string? GpuType { get; set; }

    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }

    [JsonPropertyName("numaNodesData")]
    public List<NumaNodeDataModel>? NumaNodesData { get; set; }

    [JsonPropertyName("vmUsedMemory")]
    public Dictionary<string, VMMemoryModel>? VMUsedMemory { get; set; }
}
