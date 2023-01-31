using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.DeviceCapacityInfo;


internal class NumaNodeDataModel
{
    [JsonPropertyName("effectiveAvailableMemoryInMb")]
    public int? EffectiveAvailableMemoryInMb { get; set; }

    [JsonPropertyName("freeVCpuIndexesForHpn")]
    public List<int>? FreeVCPUIndexesForHpn { get; set; }

    [JsonPropertyName("logicalCoreCountPerCore")]
    public int? LogicalCoreCountPerCore { get; set; }

    [JsonPropertyName("numaNodeIndex")]
    public int? NumaNodeIndex { get; set; }

    [JsonPropertyName("totalMemoryInMb")]
    public int? TotalMemoryInMb { get; set; }

    [JsonPropertyName("vCpuIndexesForHpn")]
    public List<int>? VCPUIndexesForHpn { get; set; }

    [JsonPropertyName("vCpuIndexesForRoot")]
    public List<int>? VCPUIndexesForRoot { get; set; }
}
