using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.ResourcePools;


internal class ResourcePoolPropertiesModel
{
    [JsonPropertyName("cpuLimitMHz")]
    public int? CpuLimitMHz { get; set; }

    [JsonPropertyName("cpuReservationMHz")]
    public int? CpuReservationMHz { get; set; }

    [JsonPropertyName("cpuSharesLevel")]
    public string? CpuSharesLevel { get; set; }

    [JsonPropertyName("customResourceName")]
    public string? CustomResourceName { get; set; }

    [JsonPropertyName("inventoryItemId")]
    public string? InventoryItemId { get; set; }

    [JsonPropertyName("memLimitMB")]
    public int? MemLimitMB { get; set; }

    [JsonPropertyName("memReservationMB")]
    public int? MemReservationMB { get; set; }

    [JsonPropertyName("memSharesLevel")]
    public string? MemSharesLevel { get; set; }

    [JsonPropertyName("moName")]
    public string? MoName { get; set; }

    [JsonPropertyName("moRefId")]
    public string? MoRefId { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("statuses")]
    public List<ResourceStatusModel>? Statuses { get; set; }

    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; }

    [JsonPropertyName("vCenterId")]
    public string? VCenterId { get; set; }
}
