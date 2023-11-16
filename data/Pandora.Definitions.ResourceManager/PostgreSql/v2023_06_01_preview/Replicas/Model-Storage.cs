using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.Replicas;


internal class StorageModel
{
    [JsonPropertyName("autoGrow")]
    public StorageAutoGrowConstant? AutoGrow { get; set; }

    [JsonPropertyName("iops")]
    public int? Iops { get; set; }

    [JsonPropertyName("storageSizeGB")]
    public int? StorageSizeGB { get; set; }

    [JsonPropertyName("throughput")]
    public int? Throughput { get; set; }

    [JsonPropertyName("tier")]
    public AzureManagedDiskPerformanceTiersConstant? Tier { get; set; }

    [JsonPropertyName("type")]
    public StorageTypeConstant? Type { get; set; }
}
