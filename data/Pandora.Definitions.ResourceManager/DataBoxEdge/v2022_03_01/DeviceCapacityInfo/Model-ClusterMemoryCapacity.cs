using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.DeviceCapacityInfo;


internal class ClusterMemoryCapacityModel
{
    [JsonPropertyName("clusterFailoverMemoryMb")]
    public float? ClusterFailoverMemoryMb { get; set; }

    [JsonPropertyName("clusterFragmentationMemoryMb")]
    public float? ClusterFragmentationMemoryMb { get; set; }

    [JsonPropertyName("clusterFreeMemoryMb")]
    public float? ClusterFreeMemoryMb { get; set; }

    [JsonPropertyName("clusterHypervReserveMemoryMb")]
    public float? ClusterHypervReserveMemoryMb { get; set; }

    [JsonPropertyName("clusterInfraVmMemoryMb")]
    public float? ClusterInfraVMMemoryMb { get; set; }

    [JsonPropertyName("clusterMemoryUsedByVmsMb")]
    public float? ClusterMemoryUsedByVMsMb { get; set; }

    [JsonPropertyName("clusterNonFailoverVmMb")]
    public float? ClusterNonFailoverVMMb { get; set; }

    [JsonPropertyName("clusterTotalMemoryMb")]
    public float? ClusterTotalMemoryMb { get; set; }

    [JsonPropertyName("clusterUsedMemoryMb")]
    public float? ClusterUsedMemoryMb { get; set; }
}
