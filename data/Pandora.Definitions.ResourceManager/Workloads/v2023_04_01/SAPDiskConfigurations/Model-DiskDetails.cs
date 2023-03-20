using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPDiskConfigurations;


internal class DiskDetailsModel
{
    [JsonPropertyName("diskTier")]
    public string? DiskTier { get; set; }

    [JsonPropertyName("iopsReadWrite")]
    public int? IopsReadWrite { get; set; }

    [JsonPropertyName("maximumSupportedDiskCount")]
    public int? MaximumSupportedDiskCount { get; set; }

    [JsonPropertyName("mbpsReadWrite")]
    public int? MbpsReadWrite { get; set; }

    [JsonPropertyName("minimumSupportedDiskCount")]
    public int? MinimumSupportedDiskCount { get; set; }

    [JsonPropertyName("sizeGB")]
    public int? SizeGB { get; set; }

    [JsonPropertyName("sku")]
    public DiskSkuModel? Sku { get; set; }
}
