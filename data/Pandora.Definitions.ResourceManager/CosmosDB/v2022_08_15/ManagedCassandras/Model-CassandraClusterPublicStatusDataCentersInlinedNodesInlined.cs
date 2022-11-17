using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_08_15.ManagedCassandras;


internal class CassandraClusterPublicStatusDataCentersInlinedNodesInlinedModel
{
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("cpuUsage")]
    public float? CpuUsage { get; set; }

    [JsonPropertyName("diskFreeKB")]
    public int? DiskFreeKB { get; set; }

    [JsonPropertyName("diskUsedKB")]
    public int? DiskUsedKB { get; set; }

    [JsonPropertyName("hostID")]
    public string? HostID { get; set; }

    [JsonPropertyName("load")]
    public string? Load { get; set; }

    [JsonPropertyName("memoryBuffersAndCachedKB")]
    public int? MemoryBuffersAndCachedKB { get; set; }

    [JsonPropertyName("memoryFreeKB")]
    public int? MemoryFreeKB { get; set; }

    [JsonPropertyName("memoryTotalKB")]
    public int? MemoryTotalKB { get; set; }

    [JsonPropertyName("memoryUsedKB")]
    public int? MemoryUsedKB { get; set; }

    [JsonPropertyName("rack")]
    public string? Rack { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("state")]
    public NodeStateConstant? State { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("timestamp")]
    public string? Timestamp { get; set; }

    [JsonPropertyName("tokens")]
    public List<string>? Tokens { get; set; }
}
