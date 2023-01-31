using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.DeviceCapacityInfo;


internal class ClusterCapacityViewDataModel
{
    [JsonPropertyName("fqdn")]
    public string? Fqdn { get; set; }

    [JsonPropertyName("gpuCapacity")]
    public ClusterGpuCapacityModel? GpuCapacity { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastRefreshedTime")]
    public DateTime? LastRefreshedTime { get; set; }

    [JsonPropertyName("memoryCapacity")]
    public ClusterMemoryCapacityModel? MemoryCapacity { get; set; }

    [JsonPropertyName("totalProvisionedNonHpnCores")]
    public int? TotalProvisionedNonHpnCores { get; set; }
}
