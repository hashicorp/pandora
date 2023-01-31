using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.DeviceCapacityInfo;


internal class ClusterGpuCapacityModel
{
    [JsonPropertyName("gpuFreeUnitsCount")]
    public int? GpuFreeUnitsCount { get; set; }

    [JsonPropertyName("gpuReservedForFailoverUnitsCount")]
    public int? GpuReservedForFailoverUnitsCount { get; set; }

    [JsonPropertyName("gpuTotalUnitsCount")]
    public int? GpuTotalUnitsCount { get; set; }

    [JsonPropertyName("gpuType")]
    public string? GpuType { get; set; }

    [JsonPropertyName("gpuUsedUnitsCount")]
    public int? GpuUsedUnitsCount { get; set; }
}
