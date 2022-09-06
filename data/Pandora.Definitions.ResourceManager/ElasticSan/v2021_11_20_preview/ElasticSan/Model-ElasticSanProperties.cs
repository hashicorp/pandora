using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ElasticSan.v2021_11_20_preview.ElasticSan;


internal class ElasticSanPropertiesModel
{
    [JsonPropertyName("availabilityZones")]
    public List<string>? AvailabilityZones { get; set; }

    [JsonPropertyName("baseSizeTiB")]
    [Required]
    public int BaseSizeTiB { get; set; }

    [JsonPropertyName("extendedCapacitySizeTiB")]
    [Required]
    public int ExtendedCapacitySizeTiB { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStatesConstant? ProvisioningState { get; set; }

    [JsonPropertyName("sku")]
    [Required]
    public SkuModel Sku { get; set; }

    [JsonPropertyName("totalIops")]
    public int? TotalIops { get; set; }

    [JsonPropertyName("totalMBps")]
    public int? TotalMBps { get; set; }

    [JsonPropertyName("totalSizeTiB")]
    public int? TotalSizeTiB { get; set; }

    [JsonPropertyName("totalVolumeSizeGiB")]
    public int? TotalVolumeSizeGiB { get; set; }

    [JsonPropertyName("volumeGroupCount")]
    public int? VolumeGroupCount { get; set; }
}
